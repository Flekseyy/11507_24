using System;

namespace CoffeeMachine;

public class ProcessCoffee
    {
        private readonly CoffeeShop _shop;
        private readonly Reader _reader;
        private readonly Validator _validator;

        public ProcessCoffee()
        {
            _shop = new CoffeeShop();
            _reader = new Reader();
            _validator = new Validator();
        }

        public void Run()
        {
            while (true)
            {
                ShowMenu();
                switch (_reader.Read())
                {
                    case "1": BuyCoffee(); break;
                    case "2": AddBalance(); break;
                    case "3": _shop.Stats.ShowReport(); break;
                    case "4": _shop.EndShift(); break;
                    case "5": return;
                    default: ShowError("Неверный выбор"); break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=== КОФЕ МАШИНА ===");
            Console.WriteLine($"Баланс: {_shop.Balance} руб");
            Console.WriteLine($"Ингредиенты: В={_shop.Water}, М={_shop.Milk}, З={_shop.Beans}");
            Console.WriteLine("1. Купить кофе\n2. Пополнить\n3. Статистика\n4. Конец смены\n5. Выход");
            Console.Write("Выбор: ");
        }

        private void BuyCoffee()
        {
            Console.Clear();
            Console.WriteLine("=== КОФЕ ===");
            for (int i = 0; i < _shop.Coffees.Length; i++)
                Console.WriteLine($"{i + 1}. {_shop.Coffees[i]}");

            if (!_validator.TryChoice(_reader.Read(), _shop.Coffees.Length, out var idx))
                return;

            var coffee = _shop.Get(_shop.Coffees, idx - 1);
            if (coffee == null || !coffee.IsAvailable)
            {
                ShowError("Недоступно");
                return;
            }
            if (!_shop.HasIngredients(coffee))
            {
                ShowError("Нет ингредиентов");
                return;
            }
            if (_shop.Balance < coffee.Price)
            {
                ShowError("Не хватает денег");
                return;
            }

            var syrups = SelectSyrups(coffee.Price);
            CompleteOrder(coffee, syrups);
        }

        private List<Syrup> SelectSyrups(int coffeePrice)
        {
            var selected = new List<Syrup>();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Сумма: {coffeePrice + selected.Sum(s => s.Price)} руб");
                Console.WriteLine("=== СИРОПЫ ===");
                for (int i = 0; i < _shop.Syrups.Length; i++)
                    Console.WriteLine($"{i + 1}. {_shop.Syrups[i]}");
                Console.WriteLine("0. Готово");
                Console.Write("Выбор: ");

                var input = _reader.Read();
                if (input == "0") break;

                if (!_validator.TryChoice(input, _shop.Syrups.Length, out var idx))
                    continue;

                var syrup = _shop.Get(_shop.Syrups, idx - 1);
                if (syrup == null || !syrup.IsAvailable || selected.Contains(syrup))
                    continue;
                if (_shop.Balance < coffeePrice + selected.Sum(s => s.Price) + syrup.Price)
                    continue;

                selected.Add(syrup);
            }
            
            return selected;
        }

        private void CompleteOrder(Coffee coffee, List<Syrup> syrups)
        {
            var total = coffee.Price + syrups.Sum(s => s.Price);
            
            Console.Clear();
            Console.WriteLine("=== ЗАКАЗ ===");
            Console.WriteLine($"{coffee.Name}: {coffee.Price} руб");
            foreach (var s in syrups)
                Console.WriteLine($"+{s.Name}: {s.Price} руб");
            Console.WriteLine($"Итого: {total} руб");
            Console.Write("Подтвердить (Y/N): ");

            if (_reader.Read().ToUpper() != "Y")
                return;

            if (_shop.Pay(total))
            {
                coffee.DecreaseCount();
                _shop.UseIngredients(coffee);
                _shop.LogSale(coffee.Name, coffee.Price);
                _shop.Stats.RecordCoffee(coffee.Name);

                foreach (var s in syrups)
                {
                    s.DecreaseCount();
                    _shop.LogSale(s.Name, s.Price);
                    _shop.Stats.RecordSyrup(s.Name);
                }

                Console.WriteLine($"\nГотово! Сдача: {_shop.Balance} руб");
                Console.WriteLine($"Доппингов: {syrups.Count}");
            }
            
            Console.WriteLine("\nEnter...");
            Console.ReadLine();
        }

        private void AddBalance()
        {
            Console.Clear();
            Console.Write("Сумма: ");
            if (_validator.TryInt(_reader.Read(), out var amount) && amount > 0)
            {
                _shop.AddBalance(amount);
                Console.WriteLine($"Баланс: {_shop.Balance} руб");
            }
            else
                ShowError("Ошибка");
            Console.WriteLine("Enter...");
            Console.ReadLine();
        }

        private void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
            Console.WriteLine("Enter...");
            Console.ReadLine();
        }
    }