using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();
			try
			{
				Console.Write("Enter a name for the Gradebook: ");
				book.Name = Console.ReadLine();
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
			// Since we added the additonal if statement in the GradeBook.Name property
			// this really isn't needed.
			catch (NullReferenceException)
			{
				Console.WriteLine("Something went wrong");
			}

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
            book.WriteGrades(Console.Out);

            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }
    }
}