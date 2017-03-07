using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    public class GradeStatistics
    {
        // Initialize float variables
        public float AverageGrade, HighestGrade, LowestGrade;

        /// <summary>
        /// Description property used to hold the description of the letter grade
        /// </summary>
        public string Description
        {
            get
            {
                string result;
                switch(LetterGrade)
                {
                    case "A":
                        result = "Excellent";
                        break;
                    case "B":
                        result = "Good";
                        break;
                    case "C":
                        result = "Average";
                        break;
                    case "D":
                        result = "Below Average";
                        break;
                    default:
                        result = "Failing";
                        break;
                }

                return result;
            }
        }

        /// <summary>
        /// LetterGrade property that is used to define a letter grade based on the score of the AverageGrade
        /// </summary>
        public string LetterGrade
        {
            get
            {
                string result;

                if (AverageGrade >= 90)
                {
                    result = "A";
                }
                else if (AverageGrade >= 80)
                {
                    result = "B";
                }
                else if (AverageGrade >= 70)
                {
                    result = "C";
                }
                else if (AverageGrade >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }

                return result;
            }
        }

        /// <summary>
        /// Constructor used to initialize Highest and Lowest Grades
        /// </summary>
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }
    }
}
