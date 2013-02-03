using System.Collections.Generic;

namespace Fizzle
{
    public class FizzBuzzer
    {
        public string Answer(int i)
        {
            if (i < 1)
                return "";
            if (i % 15 == 0)
                return "FizzBuzz";
            if (i % 5 == 0)
                return "Buzz"; 
            if (i % 3 == 0)
                return "Fizz";
            return i.ToString();
        }

        public List<string> Sequence(int first, int last)
        {
            var series = new List<string>();
            if (first < 1 || last < 1)
                return series;
            for (int number = first; number <= last; number++)
            {
                series.Add(Answer(number));
            }
            return series;
        }

    }
}
