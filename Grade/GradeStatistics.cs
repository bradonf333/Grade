using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    public class GradeStatistics
    {
        public float AverageGrade, HighestGrade, LowestGrade;

        public string LetterGrade
        {
            get
            {
                string result;
                if(AverageGrade >= 90)
                {
                    result = "A";
                }
                else if(AverageGrade >= 80)
                {
                    result = "B";
                }
                else if(AverageGrade >= 70)
                {
                    result = "C";
                }
                else if(AverageGrade >= 60)
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

        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }
    }
}
