using System.Reflection;
using _11507_24.Homework._23._05._2026.Utils.MyAttributes;
using _11507_24.Homework._23._05._2026.Utils.Validators.Abstraction;

namespace _11507_24.Homework._23._05._2026.Utils.Validators.Implementation;

public class UniversalValidator : IValidator
{
        /// <summary>
        /// Универсальный метод, который валидирует ВООБЩЕ любой объект на основе его атрибутов.
        /// </summary>
        public bool Validate(object? obj, out List<string> errors)
        {
            errors = new List<string>();
            // TODO: Проверить на null
            if (obj is  null)
            {
                errors.Add("Object cannot be null");
                return false;
            }
            // TODO: ШАГ 1. Получить тип объекта 
            var type = obj.GetType();
             // TODO: ШАГ 2. Извлечь все свойства
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            // TODO: ШАГ 3. Получать все значения свойств у ТЕКУЩЕГО экземпляра
            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                // TODO: ШАГ 3.1 Проверять, обвешано ли свойство атрибутом MyRequired
                var requiredAttribute = property.GetCustomAttribute<MyRequiredAttribute>();
                if (requiredAttribute is not null)
                {
                    if (value is null || (value is string str && string.IsNullOrWhiteSpace(str)))
                    {
                        errors.Add($"Property {property.Name} - {requiredAttribute.ErrorMessage}");
                    }
                }

                // TODO: ШАГ 3.2 Проверять, есть ли атрибут MyRange
                var rangeAttr = property.GetCustomAttribute<MyRangeAttribute>();

                if (value is int intValue)
                {
                    if (intValue < rangeAttr.Min || intValue > rangeAttr.Max)
                    {
                        errors.Add(
                            $"{property.Name}: {rangeAttr.ErrorMessage} (допустимо: {rangeAttr.Min} - {rangeAttr.Max})");
                    }
                }
            }
            return errors.Count == 0;
        }
}