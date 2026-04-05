using System;

namespace CoffeeMachine;
public class Validator
{
    public bool TryInt(string input, out int result) =>
        int.TryParse(input, out result);

    public bool TryChoice(string input, int max, out int choice)
    {
        choice = 0;
        return !string.IsNullOrWhiteSpace(input) && 
               int.TryParse(input, out choice) && 
               choice >= 1 && choice <= max;
    }
}