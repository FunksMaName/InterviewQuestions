
namespace InterviewQuestions.Console
{
    #region Using Directives

    using System;

    using System.Linq;

    using Console = System.Console;

    using InterviewQuestions.FrogJumps;

    using InterviewQuestions.IndicesAndSum;

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tWelcome");

            if (args == null || !args.Any())
            {
                Usage();
            }
            else
            {
                ProcessInput(args.First());    
            }
        }

        static void Usage()
        {
            Console.WriteLine("\tEnter 1 for the indices exercise");
            Console.WriteLine("\tEnter 2 for the frog jump exercise");

            var result = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(result))
            {
                ProcessInput(result);
            }
            else
            {
                Console.WriteLine();
                Usage();
            }
        }

        static  void ProcessInput(string arg)
        {
            arg = arg.ToLowerInvariant();

            switch (arg)
            {
                case "1":
                    ProcessIndices();
                    break;

                case "2":
                    ProcessFrogJump();
                    break;

                default:
                    Usage();
                    break;
            }
        }

        static void ProcessFrogJump()
        {
            Console.WriteLine("\tEnter a target count");
            var count = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(count))
            {
                var stepsPermutations = FrogJumps.ComputeTotalSteps(Convert.ToInt32(count));

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\tThere are { stepsPermutations } permutations");
                Console.ResetColor();
                Console.WriteLine();
                Usage();
            }
            else
            {
                ProcessFrogJump();
            }
        }

        static void ProcessIndices()
        {
            Console.WriteLine("\tEnter a tab delimited set of positive integers");
            var numbers = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(numbers))
            {
                var array = numbers.Split('\t').Select(a => Convert.ToInt32(a)).ToList();

                Console.WriteLine("\tEnter a target sum");

                var sum = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(sum))
                {
                    ProcessIndices();
                }


                if (!array.Any())
                {
                    ProcessIndices();
                }

                var indices = IndicesAndSum.FindSumIndices(array, Convert.ToInt64(sum));

                if (indices == null)
                {
                    Console.WriteLine("\tNo indices found");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\tThe following indices were found");
                    Console.WriteLine("\t================================");
                    Console.ResetColor();

                    foreach (var index in indices)
                    {
                        Console.WriteLine($"\t{ index.Item1 }, { index.Item2 }");
                    }
                    Console.WriteLine();
                    Usage();
                }
            }
        }
    }
}
