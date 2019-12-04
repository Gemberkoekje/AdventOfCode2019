using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodePart7
{
    class Program
    {
        static int digitlow = 206938;
        static int digithigh = 679128;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int amount = 0;
            for (int pw = digitlow; pw <= digithigh; pw++)
            {
                int lastdigit = -1;
                bool hasadjacentdigits = false;
                bool digitsneverdecrease = true;
                Dictionary<int, int> Digits = new Dictionary<int, int>();
                
                foreach(char digit in pw.ToString())
                {
                    int nr = int.Parse(digit.ToString());
                    if(Digits.ContainsKey(nr))
                    {
                        Digits[nr]++;
                    }
                    else
                    {
                        Digits.Add(nr, 1);
                    }
                    if(lastdigit == nr)
                    {
                        hasadjacentdigits = true;
                    }
                    if(nr < lastdigit)
                    {
                        digitsneverdecrease = false;
                    }
                    lastdigit = nr;
                }
                if(hasadjacentdigits && digitsneverdecrease && Digits.Any(d => d.Value == 2))
                {
                    Console.WriteLine(pw);
                    amount++;
                }
            }
            Console.WriteLine(string.Format("Total: {0}", amount));

        }
    }
}
