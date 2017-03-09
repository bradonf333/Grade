using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    public abstract class GradeTracker : IGradeTracker
    {
        /*--
         * I know that the GradeBook will need to track grades but I am not sure of how they 
         * will track them. Will they use a list or an array? Will it be be stored in a file 
         * or a database?
         * --
         * If I mark this as abstract then the implementation of this can be decided later when they
         * use the object. The implementation details can be decided in the derived class.
         * --
         */
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();
        
        /// <summary>
        /// Name property
        /// Makes sure name is not null or empty
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }

                if (name != value && NameChanged != null)
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
        protected string name;
        public event NameChangedDelegate NameChanged;
    }
}
