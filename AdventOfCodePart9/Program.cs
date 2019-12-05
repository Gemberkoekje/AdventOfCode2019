using System;
using System.Linq;

namespace AdventOfCodePart10
{
    class Program
    {
        static readonly int[] initmemory = new int[]
            {
                3,225,1,225,6,6,1100,1,238,225,104,0,1101,61,45,225,102,94,66,224,101,-3854,224,224,4,224,102,8,223,223,1001,224,7,224,1,223,224,223,1101,31,30,225,1102,39,44,224,1001,224,-1716,224,4,224,102,8,223,223,1001,224,7,224,1,224,223,223,1101,92,41,225,101,90,40,224,1001,224,-120,224,4,224,102,8,223,223,1001,224,1,224,1,223,224,223,1101,51,78,224,101,-129,224,224,4,224,1002,223,8,223,1001,224,6,224,1,224,223,223,1,170,13,224,101,-140,224,224,4,224,102,8,223,223,1001,224,4,224,1,223,224,223,1101,14,58,225,1102,58,29,225,1102,68,70,225,1002,217,87,224,101,-783,224,224,4,224,102,8,223,223,101,2,224,224,1,224,223,223,1101,19,79,225,1001,135,42,224,1001,224,-56,224,4,224,102,8,223,223,1001,224,6,224,1,224,223,223,2,139,144,224,1001,224,-4060,224,4,224,102,8,223,223,101,1,224,224,1,223,224,223,1102,9,51,225,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,1008,677,226,224,102,2,223,223,1006,224,329,101,1,223,223,108,677,677,224,102,2,223,223,1005,224,344,101,1,223,223,107,677,677,224,1002,223,2,223,1005,224,359,101,1,223,223,1107,226,677,224,1002,223,2,223,1005,224,374,1001,223,1,223,1008,677,677,224,102,2,223,223,1006,224,389,1001,223,1,223,1007,677,677,224,1002,223,2,223,1006,224,404,1001,223,1,223,8,677,226,224,102,2,223,223,1005,224,419,1001,223,1,223,8,226,226,224,102,2,223,223,1006,224,434,101,1,223,223,1107,226,226,224,1002,223,2,223,1006,224,449,101,1,223,223,1107,677,226,224,102,2,223,223,1005,224,464,101,1,223,223,1108,226,226,224,102,2,223,223,1006,224,479,1001,223,1,223,7,677,677,224,1002,223,2,223,1006,224,494,101,1,223,223,7,677,226,224,102,2,223,223,1005,224,509,101,1,223,223,1108,226,677,224,1002,223,2,223,1006,224,524,101,1,223,223,8,226,677,224,1002,223,2,223,1005,224,539,101,1,223,223,1007,226,226,224,102,2,223,223,1006,224,554,1001,223,1,223,108,226,226,224,1002,223,2,223,1006,224,569,1001,223,1,223,1108,677,226,224,102,2,223,223,1005,224,584,101,1,223,223,108,226,677,224,102,2,223,223,1005,224,599,101,1,223,223,1007,226,677,224,102,2,223,223,1006,224,614,1001,223,1,223,1008,226,226,224,1002,223,2,223,1006,224,629,1001,223,1,223,107,226,226,224,1002,223,2,223,1006,224,644,101,1,223,223,7,226,677,224,102,2,223,223,1005,224,659,1001,223,1,223,107,677,226,224,102,2,223,223,1005,224,674,1001,223,1,223,4,223,99,226


            };
        static int[] memory = new int[]
            {
                //3,225,1,225,6,6,1100,1,238,225,104,0,1101,61,45,225,102,94,66,224,101,-3854,224,224,4,224,102,8,223,223,1001,224,7,224,1,223,224,223,1101,31,30,225,1102,39,44,224,1001,224,-1716,224,4,224,102,8,223,223,1001,224,7,224,1,224,223,223,1101,92,41,225,101,90,40,224,1001,224,-120,224,4,224,102,8,223,223,1001,224,1,224,1,223,224,223,1101,51,78,224,101,-129,224,224,4,224,1002,223,8,223,1001,224,6,224,1,224,223,223,1,170,13,224,101,-140,224,224,4,224,102,8,223,223,1001,224,4,224,1,223,224,223,1101,14,58,225,1102,58,29,225,1102,68,70,225,1002,217,87,224,101,-783,224,224,4,224,102,8,223,223,101,2,224,224,1,224,223,223,1101,19,79,225,1001,135,42,224,1001,224,-56,224,4,224,102,8,223,223,1001,224,6,224,1,224,223,223,2,139,144,224,1001,224,-4060,224,4,224,102,8,223,223,101,1,224,224,1,223,224,223,1102,9,51,225,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,1008,677,226,224,102,2,223,223,1006,224,329,101,1,223,223,108,677,677,224,102,2,223,223,1005,224,344,101,1,223,223,107,677,677,224,1002,223,2,223,1005,224,359,101,1,223,223,1107,226,677,224,1002,223,2,223,1005,224,374,1001,223,1,223,1008,677,677,224,102,2,223,223,1006,224,389,1001,223,1,223,1007,677,677,224,1002,223,2,223,1006,224,404,1001,223,1,223,8,677,226,224,102,2,223,223,1005,224,419,1001,223,1,223,8,226,226,224,102,2,223,223,1006,224,434,101,1,223,223,1107,226,226,224,1002,223,2,223,1006,224,449,101,1,223,223,1107,677,226,224,102,2,223,223,1005,224,464,101,1,223,223,1108,226,226,224,102,2,223,223,1006,224,479,1001,223,1,223,7,677,677,224,1002,223,2,223,1006,224,494,101,1,223,223,7,677,226,224,102,2,223,223,1005,224,509,101,1,223,223,1108,226,677,224,1002,223,2,223,1006,224,524,101,1,223,223,8,226,677,224,1002,223,2,223,1005,224,539,101,1,223,223,1007,226,226,224,102,2,223,223,1006,224,554,1001,223,1,223,108,226,226,224,1002,223,2,223,1006,224,569,1001,223,1,223,1108,677,226,224,102,2,223,223,1005,224,584,101,1,223,223,108,226,677,224,102,2,223,223,1005,224,599,101,1,223,223,1007,226,677,224,102,2,223,223,1006,224,614,1001,223,1,223,1008,226,226,224,1002,223,2,223,1006,224,629,1001,223,1,223,107,226,226,224,1002,223,2,223,1006,224,644,101,1,223,223,7,226,677,224,102,2,223,223,1005,224,659,1001,223,1,223,107,677,226,224,102,2,223,223,1005,224,674,1001,223,1,223,4,223,99,226



            };

        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
                    memory = (int[])initmemory.Clone();
                    int instructionPointer = 0;
                    int retval = 0;
                    while (retval != -1)
                    {
                        retval = HandleIntCode(instructionPointer);
                        if (retval != -1)
                        {
                            instructionPointer = retval;
                        }
                    }

        }

        public static int HandleIntCode(int start)
        {
            var operation = memory[start];
            var operationstring = operation.ToString();
            int pos2 = 0;
            int pos = operationstring.Length - 1;
            string opcodestr = "";
            int modepar1 = 0;
            int modepar2 = 0;
            int modepar3 = 0;
            while(pos >= 0)
            {
                var t = operationstring[pos];
                if(pos2 < 2)
                    opcodestr = string.Format("{0}{1}", t.ToString(), opcodestr);
                if (pos2 == 2)
                    modepar1 = int.Parse(t.ToString());
                if (pos2 == 3)
                    modepar2 = int.Parse(t.ToString());
                if (pos2 == 4)
                    modepar3 = int.Parse(t.ToString());
                pos--;
                pos2++;
            }
            int opcode = int.Parse(opcodestr);
            int input1 = -1;
            int input2 = -1;
            int input3 = -1;
            int output = -1;
            int nextcode = -1;
            if (opcode == 1 || opcode == 2)
            {
                input1 = memory[start + 1];
                input2 = memory[start + 2];
                input3 = memory[start + 3];
                output = memory[start + 3];
                nextcode = 4;
            }
            if (opcode == 3)
            {
                input1 = memory[start + 1];
                output = memory[start + 1];
                nextcode = 2;
            }
            if (opcode == 4)
            {
                input1 = memory[start + 1];
                nextcode = 2;
            }
            if (opcode == 5)
            {
                input1 = memory[start + 1];
                input2 = memory[start + 2];
                nextcode = 3;
            }
            if (opcode == 6)
            {
                input1 = memory[start + 1];
                input2 = memory[start + 2];
                nextcode = 3;
            }
            if (opcode == 7)
            {
                input1 = memory[start + 1];
                input2 = memory[start + 2];
                input3 = memory[start + 3];
                output = memory[start + 3];
                nextcode = 4;
            }
            if (opcode == 8)
            {
                input1 = memory[start + 1];
                input2 = memory[start + 2];
                input3 = memory[start + 3];
                output = memory[start + 3];
                nextcode = 4;
            }
            int inputvar1 = -1;
            int inputvar2 = -1;
            int inputvar3 = -1;
            if (modepar1 == 0 && input1 != -1)
                inputvar1 = memory[input1];
            else if (modepar1 == 1)
                inputvar1 = input1;
            if (modepar2 == 0 && input2 != -1)
                inputvar2 = memory[input2];
            else if (modepar2 == 1)
                inputvar2 = input2;
            if (modepar3 == 0 && input3 != -1)
                inputvar3 = memory[input3];
            else if (modepar3 == 1)
                inputvar3 = input3;
            switch (opcode)
            {
                case 1:
                    Console.WriteLine(string.Format("({4}) Executing {0}: {1} + {2} to {3}", operation, inputvar1, inputvar2, output, start));
                    memory[output] = inputvar1 + inputvar2;
                    return start + nextcode;
                case 2:
                    Console.WriteLine(string.Format("({4}) Executing {0}: {1} * {2} to {3}", operation, inputvar1, inputvar2, output, start));
                    memory[output] = inputvar1 * inputvar2;
                    return start + nextcode;
                case 3:
                    Console.WriteLine(string.Format("Enter input for ({0}):", start));
                    var clientinput = Console.ReadLine();
                    var intinput = int.Parse(clientinput);
                    Console.WriteLine(string.Format("({3}) Executing {0}: {1} to {2}", operation, intinput, output, start));
                    memory[output] = intinput;
                    return start + nextcode;
                case 4:
                    Console.WriteLine(string.Format("({1}) Executing {0}", operation, start));
                    Console.WriteLine(string.Format("--- OUTPUT OF {0} is {1} ---", start, inputvar1));
                    return start + nextcode;
                case 5:
                    Console.WriteLine(string.Format("({1}) Executing {0}:", operation, start));
                    if (inputvar1 == 0)
                    {
                        Console.WriteLine(string.Format("    not jumping with input {0}", inputvar1));
                        return start + nextcode;
                    }
                    else
                    {
                        Console.WriteLine(string.Format("    jumping to {1} with input {0}", inputvar1, inputvar2));
                        return inputvar2;
                    }
                case 6:
                    Console.WriteLine(string.Format("({1}) Executing {0}:", operation, start));
                    if (inputvar1 != 0)
                    {
                        Console.WriteLine(string.Format("    not jumping with input {0}", inputvar1));
                        return start + nextcode;
                    }
                    else
                    {
                        Console.WriteLine(string.Format("    jumping to {1} with input {0}", inputvar1, inputvar2));
                        return inputvar2;
                    }
                case 7:
                    Console.WriteLine(string.Format("({4}) Executing {0}: {1} < {2} to {3}", operation, inputvar1, inputvar2, output, start));
                    memory[output] = inputvar1 < inputvar2 ? 1 : 0;
                    return start + 4;
                case 8:
                    Console.WriteLine(string.Format("({4}) Executing {0}: {1} == {2} to {3}", operation, inputvar1, inputvar2, output, start));
                    memory[output] = inputvar1 == inputvar2 ? 1 : 0;
                    return start + 4;
                case 99:
                    Console.WriteLine(string.Format("({1}) Executing {0}", operation, start));
                    return -1;
            }
            throw new ArgumentOutOfRangeException("operation");
        }

    }
}
