namespace InterviewQuestions.Tests
{
    #region Using Directives

    using FluentAssertions;

    using NUnit.Framework;

    #endregion

    /// <summary>
    ///  Test Matrix
    ///  //  F[0]    F[1]    F[2]    F[3]    F[4]    F[5]    F[6]    F[7]    F[8]    F[9]    F[10]       F[11]       F[12]
    ///  //  0       1       1       2       3       5       8       13      21      34      55          89          144          
    /// </summary>
    [TestFixture]
    public class FrogJumpsTests
    {
        [Test]
        [TestCase(5, Result = 8)]
        [TestCase(6, Result = 13)]
        [TestCase(7, Result = 21)]
        [TestCase(8, Result = 34)]
        [TestCase(9, Result = 55)]
        [TestCase(10, Result = 89)]
        [TestCase(11, Result = 144)]
        public long ComputeTotalSteps_For_Known_Values_Is_Correct(int steps)
        {
            return FrogJumps.FrogJumps.ComputeTotalSteps(steps);
        }

        [Test]
        public void ComputeTotalSteps_When_Steps_Less_Than_Or_Equal_To_Zero_Zero_Returned()
        {
            var steps = FrogJumps.FrogJumps.ComputeTotalSteps(0);

            steps.Should().Be(0, "A non-postitive integer or an integer which is less than 1 should return zero steps");
        }

        [Test]
        public void ComputeTotalSteps_When_Steps_Is_One_One_Is_Returned()
        {
            var steps = FrogJumps.FrogJumps.ComputeTotalSteps(1);

            steps.Should().Be(1, "The count should be 1 for a single target count");
        }
    }
}
