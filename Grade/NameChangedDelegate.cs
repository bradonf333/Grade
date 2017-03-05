using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
     /// <summary>
     /// An event always passes 2 parameters:
     /// 1 - The sender of the event. Send itself.
     /// 2 - All the arguments or all the needed info about the event.
     /// This requires a custom class to put together all the needed info into an object
     /// which can then be passed as the arguments.
     /// 
     /// The first parameter is an object so that way anything can be passed into it.
     /// It could be a string, an int or even an acutal object instance, in this case
     /// a Gradebook is passed.
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="args"></param>
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
}
