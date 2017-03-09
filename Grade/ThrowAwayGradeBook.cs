using System;
namespace Grade
{
	public class ThrowAwayGradeBook : GradeBook
	{
		public GradeStatistics ComputeStatistics()
		{
            Console.WriteLine("ThrowAwayGradebook::ComputeStatistics");
            float lowest = float.MaxValue;
            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }
            grades.Remove(lowest);

			// Base reaches the inherited class information.
			// This means I am accessing the GradeBook.ComputeStatistics not the ThrowAwayGradeBook.ComputeStatistics
			return base.ComputeStatistics();
		}
	}
}
