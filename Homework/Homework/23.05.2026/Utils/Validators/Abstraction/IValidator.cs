namespace _11507_24.Homework._23._05._2026.Utils.Validators.Abstraction;

public interface IValidator
{
    bool Validate(object obj, out List<string> errors);
}