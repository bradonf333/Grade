using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    /// <summary>
    /// This is a custom class created in order to access the ExistingName and the CurrentName
    /// of our Gradebook object.
    /// This is used in order to handle our Event
    /// </summary>
    public class NameChangedEventArgs : EventArgs
    {
        public string ExistingName { get; set; }
        public string NewName { get; set; }
    }
} 
