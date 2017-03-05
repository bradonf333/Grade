using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! This is the grade book program");

            GradeBook book = new GradeBook();

            book.NameChanged += OnNameChanged; // Add subscriber(OnNameChanged) to the event "NameChangedDelegate"

            book.Name = "Bradon's Grade Book";
            book.Name = "Grade book";
            book.Name = null;
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }

        /// <summary>
        /// This method takes an object parameter and an instance of the NameChangedEventArgs class.
        /// 
        /// Then to get the ExistingName and the NewName we access them via the instance of the NameChangedEventArgs.
        /// To do this we say args.ExistingName and args.NewName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:F2}", description, result);
        }
    }
}