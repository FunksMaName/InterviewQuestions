using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace InterviewQuestions.Tests
{
    [TestFixture]
    public class FrogJumpsTests
    {
        [Test]
        public void Testssss()
        {
            var results = FrogJumps.FrogJumps.ComputeStepsAndJumps(6);
            Console.WriteLine(results.Count());
            foreach (var result in results)
            {
                Console.WriteLine(string.Join(", ", result.Select(r => r)));
            }
        }
    }
}
