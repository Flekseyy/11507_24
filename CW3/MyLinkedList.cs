using System.Collections;

namespace IIP3;

public class TribonacciSequence
{
    public static IEnumerable<int> Tribonacci
    {
        get
        {
            yield return 0;
            yield return 0;
            yield return 1;
            var currentValue = 0;
            var previousValue = 0;
            var nextValue = 1;
            while (true)
            {
                var next = currentValue + previousValue  + nextValue; 
                yield return next;
                currentValue = previousValue;
                previousValue = nextValue;
                nextValue = next;

            }
        }
    }

}