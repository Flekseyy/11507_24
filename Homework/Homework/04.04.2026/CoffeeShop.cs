using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace CoffeeMachine;
public class CoffeeShop
    {
        private readonly List<Coffee> _coffees = new();
        private readonly List<Syrup> _syrups = new();
        private int _balance;
        private int _water, _milk, _beans;
        
        public Statistics Stats { get; } = new();
        private const string ConfigFile = "config.json";
        private const string SalesFile = "sales_history.txt";
        
        public Coffee[] Coffees => _coffees.ToArray();
        public Syrup[] Syrups => _syrups.ToArray();

        public int Balance => _balance;
        public int Water => _water;
        public int Milk => _milk;
        public int Beans => _beans;

        public CoffeeShop()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            ConfigData config;
            
            if (File.Exists(ConfigFile))
            {
                config = JsonSerializer.Deserialize<ConfigData>(File.ReadAllText(ConfigFile));
            }
            else
            {
                config = CreateDefaultConfig();
                SaveConfig(config);
            }

            _water = config.Water;
            _milk = config.Milk;
            _beans = config.Beans;

            foreach (var c in config.CoffeePrices)
            {
                var (water, milk) = GetIngredients(c.Key);
                _coffees.Add(new Coffee(c.Key, 10, c.Value, water, milk, 20));
            }

            foreach (var s in config.SyrupPrices)
                _syrups.Add(new Syrup(s.Key, 10, s.Value));
        }
        
        private (int water, int milk) GetIngredients(string name)
        {
            return name switch
            {
                "Americano"  => (200, 0),
                "Latte"      => (150, 100),
                "Cappuccino" => (150, 100),
                "Raff"       => (100, 120),
                _            => (150, 100)
            };
        }

        private ConfigData CreateDefaultConfig()
        {
            return new ConfigData
            {
                CoffeePrices = { 
                    {"Latte", 250}, {"Raff", 300}, 
                    {"Americano", 200}, {"Cappuccino", 230} 
                },
                SyrupPrices = { 
                    {"Caramel", 50}, {"Almond", 70}, 
                    {"Coconut", 60}, {"Hazelnut", 60} 
                }
            };
        }

        private void SaveConfig(ConfigData config)
        {
            File.WriteAllText(ConfigFile, JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void SaveConfig()
        {
            var config = new ConfigData { Water = _water, Milk = _milk, Beans = _beans };
            foreach (var c in _coffees) config.CoffeePrices[c.Name] = c.Price;
            foreach (var s in _syrups) config.SyrupPrices[s.Name] = s.Price;
            SaveConfig(config);
        }

        public void AddBalance(int amount)
        {
            if (amount > 0) _balance += amount;
        }

        public bool Pay(int amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                return true;
            }
            return false;
        }

        public bool HasIngredients(Coffee coffee) =>
            _water >= coffee.Water && _milk >= coffee.Milk && _beans >= coffee.Beans;

        public void UseIngredients(Coffee coffee)
        {
            _water -= coffee.Water;
            _milk -= coffee.Milk;
            _beans -= coffee.Beans;
            SaveConfig();
        }

        public void LogSale(string name, int price)
        {
            var record = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] Продано: {name}, Цена: {price} руб";
            File.AppendAllText(SalesFile, record + Environment.NewLine);
        }

        public void EndShift()
        {
            Console.Clear();
            Console.WriteLine("=== КОНЕЦ СМЕНЫ ===\n");

            if (!File.Exists(SalesFile))
            {
                Console.WriteLine("Нет продаж");
                Console.ReadLine();
                return;
            }

            var today = DateTime.Now.ToString("dd.MM.yyyy");
            var report = new DailyReport { Date = today };

            foreach (var line in File.ReadAllLines(SalesFile))
            {
                if (line.Contains(today) && line.Contains("Цена:"))
                {
                    try 
                    {
                        var priceStr = line.Split("Цена: ")[1].Replace("руб", "").Trim();
                        var name = line.Split("Продано: ")[1].Split(",")[0];
                        
                        if (int.TryParse(priceStr, out int price))
                        {
                            report.Sales.Add(new SalesRecord { ItemName = name, Price = price });
                            report.TotalRevenue += price;
                            report.TotalSales++;
                        }
                    }
                    catch {}
                }
            }

            var fileName = $"report_{DateTime.Now:yyyy_MM_dd}.json";
            File.WriteAllText(fileName, JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true }));
            
            Console.WriteLine($"Отчет сохранен: {fileName}");
            Console.WriteLine($"Выручка за сегодня: {report.TotalRevenue} руб");
            Console.WriteLine($"Количество чеков: {report.TotalSales}");
            
            File.WriteAllText(SalesFile, "");
            
            Console.WriteLine("\nНажмите Enter...");
            Console.ReadLine();
        }
        public T Get<T>(T[] array, int index) where T : class
        {
            if (index >= 0 && index < array.Length)
                return array[index];
            return null;
        }
    }