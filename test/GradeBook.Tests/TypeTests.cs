using System;
using Xunit;


namespace GradeBook.Tests
{
    //String is a reference type, can behave lie value type
    // public struct //struct is for value type - Int32
    // {

    // }
    //DEFINING DELEGATE PARAMETER
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {

            // WriteLogDelegate log; //declare a var named log
            WriteLogDelegate log = ReturnMessage;
            //delegate allows u to use below instead of log = new WriteLogDelegate(ReturnMessage());
            log += ReturnMessage;
            log += IncrementCount;
            // log = ReturnMessage; 
            var result = log("Hello!"); //will invoke the method Return Messgae
            
            Assert.Equal("hello!", result);
            Assert.Equal(1, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUpperCase(name);

            Assert.Equal("Scott", name);
            //Assert.Equal("SCOTT", name);

        }
        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            //to get 42 in expected, need to use ref keyword
            //using ref to change from x to z
            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

         private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            //create a single book
            var book1 = GetBook("Book 1");
            //day to day progr, no need of ref
            // can use out - output, must use initialise, book = new Book(name)
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }
        //passing book1 into book        
        private void GetBookSetNameByRef(ref InMemoryBook book, String name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            //create a single book
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");


            Assert.Equal("Book 1", book1.Name);

        }
        //passing book1 into book        
        private void GetBookSetName(InMemoryBook book, String name)
        {
            book = new InMemoryBook(name);
            //book.Name = name;
        }

        [Fact]
          //check to see if you change the name of the book
        public void CanSetNameFromReference()
        {
            //create a single book
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");


            Assert.Equal("New Name", book1.Name);

        }
        //passing book1 into book        
        private void SetName(InMemoryBook book, String name)
        {
            book.Name = name;
        }

        //fact attribute, finds which has fact
        [Fact]
        //provide different parameter types to make the method signatures distinct.
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            //copies book1 value into the next
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}