using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new ThrowAwayGradeBook();

            //GetBookName(book);
            AddGrades(book);
            WriteResults(book);
            SaveGrades(book);
        }

        private static void SaveGrades(GradeBook book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        static void WriteResults(GradeBook book)
		{
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

		static void AddGrades(GradeBook book)
		{
			book.AddGrade(91);
			book.AddGrade(89.5f);
			book.AddGrade(75);
		}

		static void GetBookName(GradeBook book)
		{
			try
			{
				Console.Write("Enter a name for the Gradebook: ");
				book.Name = Console.ReadLine();
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
    }
}