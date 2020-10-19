using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTest
    {
        [Fact]
        public void BooksCalculateAnAverageGrade()
        {
            var book = new InMemoryBook("Pride and Prejudice");

            book.AddGrade(2.0);
            book.AddGrade(10.0);
            var average = book.GetStatistics();

            Console.WriteLine(average);

            Assert.Equal(6.0, average.Average, 1);

        }
    }
}
