using System;
using System.Collections.Generic;
using System.IO;
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
                        // Create an instance of our custom class that will hold the new and old names
                        NameChangedEventArgs args = new NameChangedEventArgs();

                        // Set the ExistingName and the NewName of the custome object
                        args.ExistingName = name;
                        args.NewName = value;

                        // Invoke the NameChangedDelegate which is named NameChanged (see above)
                        // Use "this" to pass along the current object which in this case is a GradeBook.
                        NameChanged(this, args);
                    }
                    name = value;
                }
            }
        }

        public void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
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
