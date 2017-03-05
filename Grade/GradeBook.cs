using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    public class GradeBook
    {
        private string name;
        public event NameChangedDelegate NameChanged;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    if(name != value)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = name;
                        args.NewName = value;
                        NameChanged(this, args);
                    }
                    name = value;
                }
            }
        }

        private List<float> grades;

        public GradeBook()
        {
            name = "Empty";
            grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
        {
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

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }
    }
}
