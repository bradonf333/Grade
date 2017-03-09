using System;
namespace Grade
{
	public class ThrowAwayGradeBook : GradeBook
	{
		public GradeStatistics ComputeStatistics()
		{


			// Base reaches the inherited class information.
			// This means I am accessing the GradeBook.ComputeStatistics not the ThrowAwayGradeBook.ComputeStatistics
			return base.ComputeStatistics();
		}
	}
}
