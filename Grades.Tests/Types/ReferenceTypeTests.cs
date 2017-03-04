using Grade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        /// <summary>
        /// Shows that the string type is Immutable
        /// If you call a method on the string type it will return a NEW string.
        /// You have to assign that string to a variable or else the changes made will be lost.
        /// </summary>
        [TestMethod]
        public void UpperCaseString()
        {
            string name = "bradon";

            // ToUpper will return a string in uppercase. You need to assign that new value to a variable,
            // if not then nothing happens
            name.ToUpper();

            // Shows that nothing happened to the string when using the .ToUpper
            Assert.AreNotEqual("BRADON", name);

            // Assigns the new ToUpper string to the name variable
            name = name.ToUpper();
            // Shows that after we re-assigned the variable they are now equal
            Assert.AreEqual("BRADON", name);
        }

        /// <summary>
        /// Shows that the date is Immutable.
        /// You can't just use an operation like AddDays, you need to actually assign the value
        /// that is returned into a variable. The variable can be new or you can re-assign the original.
        /// </summary>
        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2017, 3, 3);
            
            // AddDays returns a new value, since we are not assigning the new value nothing happens
            date.AddDays(1); 
            Assert.AreNotEqual(4, date.Day);

            // Now we are assigning AddDays to the date variable, this will reflect the change.
            date = date.AddDays(1);
            Assert.AreEqual(4, date.Day);
        }

        /// <summary>
        /// This TestMethod will test passing value type variables into methods.
        /// Since these are value types anything done in the calling method will not affect the value
        /// types in this method. That is because they are VALUE types not REFERENCE types.
        /// 
        /// REF methods:
        /// Using the ref method will now actually change the value of the int. A reference to the int is
        /// passed into the method. Any changes within that method will now be refelected to the original int
        /// because we passed a "reference" to the int into the method.
        /// </summary>
        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x);

            Assert.AreEqual(46, x); // Nothing happened because int's are value types, not reference types

            // Pass a reference of the int into the method. Any changes will now be reflected into the original int
            IncrementNumberRef(ref x);

            Assert.AreNotEqual(46, x);
            Assert.AreEqual(47, x);
        }

        /// <summary>
        /// This method takes an int as a parameter. It will then increase the int by 1.
        /// In reality this method will NOT do anything to the int that was passed into it because 
        /// int's are a Value type NOT a Reference type. 
        /// Any changes to the int within this method will not affect the int that was passed into it.
        /// </summary>
        /// <param name="number"></param>
        private void IncrementNumber(int number)
        {
            number += 1;
        }

        /// <summary>
        /// This method is a copy of the one above only it uses the "ref" keyword.
        /// The ref keyword makes it so that whatever int is passed into this method is actually passed
        /// as a reference, meaning this method will now "reference that int's location.
        /// Any changes to the int in this method will now change the int that was passed into it.
        /// </summary>
        /// <param name="number"></param>
        private void IncrementNumberRef(ref int number)
        {
            number += 1;
        }

        /// <summary>
        /// This TestMethod will test reference type objects into methods.
        /// Since these are reference types anything done in the calling method WILL affect the reference
        /// types in this method. That is because these are REFERENCE types not VALUE types.
        /// </summary>
        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1; // Sets book2 to equal book1. These now reference the same memory location

            // Assigning book2 a name/ This will also assign book1 a name
            GiveBookAName(book2); // Assigns the value of "A Gradebook" to book2
            Assert.AreEqual("A Gradebook", book1.Name); // These are equal because book2 and book1 reference same memory location
            Assert.AreEqual(book2.Name, book1.Name); // Shows the names are equal.

            GradeBook book3 = book2; // Sets book3 to equal book2. These now reference the same memory location (including book1)

            // Calls the GiveFakeBookAName method. This method looks like it changes the books name but in reality it does not
            GiveFakeBookAName(book3);

            // All books equal each other
            Assert.AreEqual(book3, book2);
            Assert.AreEqual(book3, book1);

            GradeBook book4 = book3;

            // Before this method book4 is equal to book3. This method actually creates a new object when it is called.
            // Because of this book4 no longer equals book3. 
            // book4 is wiped clean (which removes the reference to book3's memory location)
            // book4 is then assigned a name which is different from book3's name.
            // Sidenote, book3 = book2 = book1, so book4 is different than all the rest of the books because of the "ref"
            GiveRefBookAName(ref book4);
            Assert.AreNotEqual(book4, book3);
        }

        /// <summary>
        /// This method assigns the name of a book.
        /// The Book object is passed into this method. 
        /// Since the object is a reference type any changes made in this method will affect the 
        /// object as they all point to the same reference
        /// </summary>
        /// <param name="book"></param>
        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A Gradebook";
        }

        /// <summary>
        /// This method is almost a copy of GiveBookAName with an exception.
        /// This method will create a new book object inside of the method and assign that new books name. 
        /// So if a Book object is passed into this method it won't change that book, because it creates
        /// a new book and assigns the name to the new book. While the original book is left alone.
        /// </summary>
        /// <param name="book"></param>
        private void GiveFakeBookAName(GradeBook book)
        {
            // New object is created and assigned a name, leaving the object passed into this method alone.
            book = new GradeBook();
            book.Name = "B Gradebook";
        }

        /// <summary>
        /// Ref methods can be considered as a pointer to a pointer. Or a reference to the reference.
        /// A reference of the object is passed into the method and the method uses that reference.
        /// Any changes in this method will change the original object that was passed because the ref method
        /// is now "referencing" that objects reference(memory location)
        /// </summary>
        /// <param name="book"></param>
        private void GiveRefBookAName(ref GradeBook book)
        {
            // The reference is passed in and then this creates a new object and assigns its name
            book = new GradeBook();
            book.Name = "B Gradebook";
        }

        /// <summary>
        /// This TestMethod compares an uppercase string to a lowercase string by using the string.equals class.
        /// Since one is uppercase and the other lower, we have to use the InvariantCultureIgnoreCase option.
        /// StringComparison is actually an ENUM with different options.
        /// 
        /// CurrentCulture = 0,
        /// CurrentCultureIgnoreCase = 1,
        /// InvariantCulture = 2,
        /// InvariantCultureIgnoreCase = 3,
        /// Ordinal = 4,
        /// OrdinalIgnoreCase = 5
        /// 
        /// As you can see the option we used is actually 3 behind the scenes
        /// </summary>
        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Bradon";
            string name2 = "bradon";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// This TestMethod tests how int variables hold their own values.
        /// If we create a second int variable and set it equal to the first any changes made to
        /// one int DO NOT affect the other int. This is because int variables are VALUE types and
        /// hold their value directly. They do not have a reference to a memory location.
        /// </summary>
        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            Assert.AreNotEqual(x1, x2);
        }

        /// <summary>
        /// This TestMethod tests how objects are reference types and only hold a reference to a memory location.
        /// gBook2 is set to equal gBook1. Anything done to either object will affect the other.
        /// That is because these are reference types and they reference the same location in memory.
        /// When something is changed to 1 object it changes it by the reference of the memory location that 
        /// object holds. So the other object will reference the same memory location and will reference any 
        /// changes that were made using the other object.
        /// </summary>
        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook gBook1 = new GradeBook();
            GradeBook gBook2 = gBook1;

            Assert.AreEqual(gBook1.Name, gBook2.Name);

            gBook1 = new GradeBook();
            gBook1.Name = "Bradon's Gradebook";

            Assert.AreNotEqual(gBook1.Name, gBook2.Name);
        }
    }
}
