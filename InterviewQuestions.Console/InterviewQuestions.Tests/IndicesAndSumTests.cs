using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable CollectionNeverUpdated.Local

namespace InterviewQuestions.Tests
{
    #region Using Directives

    using System.Collections.Generic;

    using FluentAssertions;

    using IndicesAndSum;
    using NUnit.Framework;

    #endregion

    [TestFixture]
    public class IndicesAndSumTests
    {
        private const string NullTupleReturned = "A null tuple should be returned as there are no matches";

        [Test]
        [TestCase(new[] { 3, 4, 5 }, Result = null, Description = NullTupleReturned)]
        [TestCase(new[] { 6, 7, 8 }, Result = null, Description = NullTupleReturned)]
        [TestCase(new[] { 9, 10, 11 }, Result = null, Description = NullTupleReturned)]
        public IEnumerable<Tuple<int, int>> FindSumIndices_When_No_Match_Found_Return_Null(IEnumerable<int> testArray)
        {
            return IndecesAndSum.FindSumIndices(testArray, 500);
        }

        [Test]
        [TestCase(new[] { 1, 3, 3, 10, 12 })]
        public void FindSumIndices_When_Array_Parameter_contains_Duplicates_Entry_Is_Filtered(IEnumerable<int> testArray)
        {
            var result = IndecesAndSum.FindSumIndices(testArray, 13);

            result.Should().NotBeNull();
            result.Should().NotContain(r => (r.Item1 == 2 && r.Item2 == 3));
        }

        [Test]
        public void FindSumIndices_When_Array_Is_Empty_Return_Null()
        {
            var testArray = new List<int>();

            var result = IndecesAndSum.FindSumIndices(testArray, 13);

            result.Should().BeNull();
        }

        [Test]
        public void FindSumIndices_When_Array_Is_Provided_Return_Correct_Indices()
        {
            var testArray =  new[] { 1, 3, 5, 7, 9 };

            var result = IndecesAndSum.FindSumIndices(testArray, 12);

            result.Should().NotBeNull();

            result.Should().HaveCount(4);

            result.Should().Contain(m => (m.Item1 == 1 && m.Item2 == 4));
            result.Should().Contain(m => (m.Item1 == 2 && m.Item2 == 3));
            result.Should().Contain(m => (m.Item1 == 3 && m.Item2 == 2));
            result.Should().Contain(m => (m.Item1 == 4 && m.Item2 == 1));
        }

        [Test]
        public void FindSumIndices_When_Array_Sum_Greater_Than_Int32_Max_No_Overflow_Exception()
        {
            var testArray = new[] { 1, 3, int.MaxValue - 1, int.MaxValue  };

            var result = IndecesAndSum.FindSumIndices(testArray, (long)int.MaxValue + 2);

            result.Should().NotBeNull();

            result.Should().HaveCount(2);

            result.Should().Contain(m => (m.Item1 == 1 && m.Item2 == 2));
            result.Should().Contain(m => (m.Item1 == 2 && m.Item2 == 1));
        }
    }
}
