
namespace InterviewQuestions.Console
{
    using IndicesAndSum;
    using System.Collections.Generic;
    using Console = System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            var array = new List<int> { 1, 3, 5, 7, 9 };

            var indeces = IndecesAndSum.FindSumIndices(array, 14);

            if (indeces != null)
            {
                foreach (var result in indeces)
                {
                    Console.WriteLine($"{result.Item1}, {result.Item2}");
                }
            }
            else
            {
                Console.WriteLine("No matches found");
            }
        }
    }
}
