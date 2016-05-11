using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable PossibleMultipleEnumeration

namespace InterviewQuestions.IndicesAndSum
{
    /// <summary>
    /// Write a function that, given a list and a target sum, returns Zero-based indices of any two distinct elements whose sum is 
    /// equal to the target sum. If there are no such elements, the function should return null.
    /// 
    /// For example:
    /// 
    /// FindTwoSums(new List{int}() {1, 3, 5, 7, 9}, 12) should return any of the following tuples of inceces:
    /// 1, 4, (3 + 9 = 12)
    /// 2, 3, (5 + 7 = 12)
    /// 3, 2, (7 + 5 = 12)
    /// 4, 1, (9 + 3 = 12)
    /// </summary>
    public class IndicesAndSum
    {
        /// <summary>
        /// TODO: If this were to be a function that needs to be highly performant
        /// It could be optimized slightly by
        /// 1) Assuming that if index 1 and 3 match, then 3 and 1 is an automatic entry,
        /// 2) Would probably not use Linq and utilise simple for loops for slight performance gains. 
        /// </summary>
        /// <param name="elements">
        /// An <see cref="IEnumerable{Int32}"/> to test.
        /// </param>
        /// <param name="targetSum">
        /// The target sum of numbers.
        /// </param>
        /// <returns>
        /// A collection of <see cref="Tuple{Int32, Int32}"/>
        /// </returns>
        public static IEnumerable<Tuple<int, int>> FindSumIndices(IEnumerable<int> elements, long targetSum)
        {
            if (elements == null) return null;

            var index = 0;
            var distinctElements = elements.Distinct().ToDictionary(key => index++, value => value);
            
            if (!distinctElements.Any())
            {
                return null;
            }

            var matches = new List<Tuple<int, int>>();

            foreach (var element in distinctElements)
            {
                var elementMatches = distinctElements.Where(e => e.Key != element.Key && ((long)e.Value + element.Value) == targetSum);

                if (elementMatches.Any())
                {
                    matches.AddRange(elementMatches.Select(m => new Tuple<int, int>(element.Key, m.Key)));
                }
            }

            return matches.Any() ? matches : null;
        }
    }
}
