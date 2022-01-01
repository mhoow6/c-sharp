using System;

namespace VeryFastCode
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceTest test = new PerformanceTest();

            while (true)
            {
                Console.WriteLine("Available tests:");
                Console.WriteLine("0: Exceptions");
                Console.WriteLine("1: Strings");
                Console.WriteLine("2: Arrays");
                Console.WriteLine("3: For/Foreach");
                Console.WriteLine("4: Structs");
                Console.WriteLine("5: Byte array copy");
                Console.WriteLine("6: Instantiation");
                Console.WriteLine("7: Property acess");
                Console.WriteLine();
                Console.Write("Please select a test (Exit: q): ");

                switch (Console.ReadLine())
                {
                    case "q":
                        return;
                    case "0":
                        test = new ExceptionTest();
                        break;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                }

                test.Progress();
            }
        }
    }
}
