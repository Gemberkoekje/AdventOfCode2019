using System;

namespace AdventOfCodePart3
{
    class Program
    {
        static int[] inputs = new int[]
            {
                1,12,2,3,
                1,1,2,3,
                1,3,4,3,
                1,5,0,3,
                2,6,1,19,
                1,5,19,23,
                2,9,23,27,
                1,6,27,31,
                1,31,9,35,
                2,35,10,39,
                1,5,39,43,
                2,43,9,47,
                1,5,47,51,
                1,51,5,55,
                1,55,9,59,
                2,59,13,63,
                1,63,9,67,
                1,9,67,71,
                2,71,10,75,
                1,75,6,79,
                2,10,79,83,
                1,5,83,87,
                2,87,10,91,
                1,91,5,95,
                1,6,95,99,
                2,99,13,103,
                1,103,6,107,
                1,107,5,111,
                2,6,111,115,
                1,115,13,119,
                1,119,2,123,
                1,5,123,0,
                99,
                2,0,14,0


            };

        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");

            int currentInput = 0;
            while (HandleIntCode(currentInput, inputs[currentInput], inputs[currentInput + 1], inputs[currentInput + 2], inputs[currentInput + 3]))
            {
                currentInput += 4;
            }

            Console.WriteLine(inputs[0]);
        }

        public static bool HandleIntCode(int start, int operation, int input1, int input2, int output)
        {
            switch(operation)
            {
                case 1:
                    Console.WriteLine(string.Format("({4}) Executing {0}: {1} + {2} to {3}", operation, inputs[input1], inputs[input2], output, start));
                    inputs[output] = inputs[input1] + inputs[input2];
                    return true;
                case 2:
                    Console.WriteLine(string.Format("({4}) Executing {0}: {1} * {2} to {3}", operation, inputs[input1], inputs[input2], output, start));
                    inputs[output] = inputs[input1] * inputs[input2];
                    return true;
                case 99:
                    Console.WriteLine(string.Format("({1}) Executing {0}", operation, start));
                    return false;
            }
            throw new ArgumentOutOfRangeException("operation");
        }

    }
}
