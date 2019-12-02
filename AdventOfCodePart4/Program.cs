using System;

namespace AdventOfCodePart4
{
    class Program
    {
        static readonly int[] initmemory = new int[]
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
        static int[] memory = new int[]
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
            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    memory = (int[])initmemory.Clone();
                    memory[1] = noun;
                    memory[2] = verb;
                    int instructionPointer = 0;
                    while (HandleIntCode(instructionPointer, memory[instructionPointer], memory[instructionPointer + 1], memory[instructionPointer + 2], memory[instructionPointer + 3]))
                    {
                        instructionPointer += 4;
                    }
                    if (memory[0] == 19690720)
                    {
                        Console.WriteLine(string.Format("Noun: {0}, Verb: {1}, Memory: {2}", noun, verb, memory[0]));
                        return;
                    }

                }
            }
        }

        public static bool HandleIntCode(int start, int operation, int input1, int input2, int output)
        {
            switch(operation)
            {
                case 1:
                    Console.WriteLine(string.Format("({4}) Executing {0}: {1} + {2} to {3}", operation, memory[input1], memory[input2], output, start));
                    memory[output] = memory[input1] + memory[input2];
                    return true;
                case 2:
                    Console.WriteLine(string.Format("({4}) Executing {0}: {1} * {2} to {3}", operation, memory[input1], memory[input2], output, start));
                    memory[output] = memory[input1] * memory[input2];
                    return true;
                case 99:
                    Console.WriteLine(string.Format("({1}) Executing {0}", operation, start));
                    return false;
            }
            throw new ArgumentOutOfRangeException("operation");
        }

    }
}
