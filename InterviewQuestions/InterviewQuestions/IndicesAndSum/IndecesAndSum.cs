using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable PossibleMultipleEnumeration

namespace InterviewQuestions.IndicesAndSum
{
    /// <summary>
    /// Write a function that, given a list and a target sum, returns Zero-based indeces of any two distinct elements whose sum is 
    /// equal to the target sum. If there are no such elements, the function should return null.
    /// 
    /// For example:
    /// 
    /// FindTwoSums(new List{int}() {1, 3, 5, 7, 9}, 12) should return any of the following tuples of inceces:
    /// 1, 4, (3 + 9 = 12)
    /// 2, 3, (5 + 7 = 12)
    /// 1, 4, (3 + 9 = 12)
    /// 3, 2, (7 + 5 = 12)
    /// 4, 1, (9 + 3 = 12)
    /// </summary>
    public class IndecesAndSum
    {
        public static IEnumerable<Tuple<int, int>> FindSumIndices(IEnumerable<int> elements, long targetSum)
        {
            var index = 0;
            var distinctElements = elements.Distinct().ToDictionary(key => index++, value => value);

            if (!distinctElements.Any())
            {
                return null;
            }

            var referenceElements = new Dictionary<int, int>(distinctElements);
            var matches = new List<Tuple<int, int>>();

            foreach (var element in distinctElements)
            {
                var elementMatches = referenceElements.Where(e => e.Key != element.Key && (e.Value + element.Value) == targetSum);

                if (elementMatches.Any())
                {
                    matches.AddRange(elementMatches.Select(m => new Tuple<int, int>(element.Key, m.Key)));
                }
            }

            return matches.Any() ? matches : null;
        }
    }
}
