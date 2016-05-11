namespace InterviewQuestions.FrogJumps
{
    /// <summary>
    /// So, It looked like a Fibonacci sequence thing, I binged the Fibonacci steps and found this document
    /// http://ms.appliedprobability.org/data/files/Articles%2033/33-1-5.pdf
    /// And a few other links :(
    /// Here's my c# implementation of 
    /// </summary>
    public class FrogJumps
    {
        public static long ComputeTotalSteps(int totalSteps)
        {
            if (totalSteps <= 0) return 0;

            var values = new long[totalSteps + 1];
            for (int i = 0; i <= totalSteps; i++)
            {
                values[i] = (i <= 1) ? 1 : values[i - 1] + values[i - 2];
            }
            return values[totalSteps];
        }
    }
}
