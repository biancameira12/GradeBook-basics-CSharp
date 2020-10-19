using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTest
    {
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetSameBook(ref book1, "Book 2");

            Assert.Equal("Book 2", book1.Name);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
        }
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
        private void GetSameBook(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
    }
}
