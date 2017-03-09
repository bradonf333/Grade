using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    public class GradeBook : GradeTracker
    {
        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }
        // Protected member can be accessed from derived classes (inherited from this class)
        protected List<float> grades;

        /// <summary>
        /// WriteGrades method used to write all grades in the given Gradebook
        /// </summary>
        /// <param name="destination"></param>
        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }

        /// <summary>
        /// Constructor for Gradebook
        /// </summary>
        public GradeBook()
        {
            name = "Empty";
            grades = new List<float>();
        }

        /// <summary>
        /// Computes the statitistics for the gradebook
        /// This includes Highest, Lowest and Average Grades
        /// </summary>
        /// <returns></returns>
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Gradebook::ComputeStatistics");

            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count();
            return stats;
        }

        /// <summary>
        /// Adds the given grade to the gradebook list
        /// </summary>
        /// <param name="grade"></param>
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }
    }
}
