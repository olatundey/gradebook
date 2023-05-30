using System;
using Xunit;
{

}

namespace GradeBook.Tests
{
    public class BookTests
    {
        //fact attribute, finds which has fact
        [Fact]
        public void BookCalculatesStatistics()
        {
            //arrange
            var book = new InMemoryBook("");
            book.AddGrade(86.6);
            book.AddGrade(94.5);
            book.AddGrade(83.9);
            // var x = 2;
            // var y = 5;
            // var expected = 7;

            //act
            var result = book.GetStatistics(); //compute the stat and return in result, instead of showstatistics
            //var result = x + y;

            //assert
            Assert.Equal(88.3, result.Average, 1); // 1 DECIMAL PLACE
            Assert.Equal(94.5, result.High, 1);
            Assert.Equal(83.9, result.Low, 1);
            Assert.Equal('B', result.Letter);

            //Assert.Equal(expected, result);
        }
    }
}