using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.FrogJumps
{
    public class FrogJumps
    {
        private const int stepDistance = 1;

        private const int jumpDistance = 2;

        public static IEnumerable<IEnumerable<int>> ComputeStepsAndJumps(int totalDistance)
        {
            var range = new List<int>();
            for (int i = 0; i < totalDistance; i++)
            {
                range.Add(i + 1);
            }
            var permutations = GetPermutations(range, totalDistance);

            return permutations;
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
