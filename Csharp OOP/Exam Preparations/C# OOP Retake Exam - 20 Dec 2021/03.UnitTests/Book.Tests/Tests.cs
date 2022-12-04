namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class Test
    {
        private Book book;

        [SetUp]
        public void SetUp()
        {
            string bookName = "Book";
            string author = "Kong";
            this.book = new Book(bookName, author);
        }

        [Test]
        public void Test_ConstructorShouldSetName()
        {
            string expectedBookName = "Book";
            string actualBookName = this.book.BookName;

            Assert.AreEqual(expectedBookName, actualBookName);
        }

        [Test]
        public void Test_ConstructorShouldSetAuthor()
        {
            string expectedAuthor = "Kong";
            string actualAuthor = this.book.Author;

            Assert.AreEqual(expectedAuthor, actualAuthor);
        }

        [Test]
        public void Test_ConstructorShouldInitializeData()
        {
            int expectedCount = 0;
            int actualCount = this.book.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_FootnoteCountPropertySholdReturnCount()
        {
            this.book.AddFootnote(1, "Book1");
            this.book.AddFootnote(2, "Book2");
            this.book.AddFootnote(3, "Book3");

            int expectedCount = 3;
            int actualCount = this.book.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_BookNamePropertySholdThrowExeption_IfBookNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() => new Book(name, "Author"));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_AuthorPropertySholdThrowExeption_IfBookNameIsNullOrEmpty(string author)
        {
            Assert.Throws<ArgumentException>(() => new Book("Book", author));
        }

        [Test]
        public void Test_AddFootnoteMethodSholdAddFootnote()
        {
            string actulaFoodNote = "Footnote #1: Book1";
            this.book.AddFootnote(1, "Book1");

            string expectedFoodNote = this.book.FindFootnote(1);

            Assert.AreEqual(expectedFoodNote, actulaFoodNote);
        }

        [Test]
        public void Test_AddFootnoteMethodSholdThrowException_IiFoodnoteExists()
        {
            this.book.AddFootnote(1, "Book1");
            this.book.AddFootnote(2, "Book2");
            Assert.Throws<InvalidOperationException>(() => this.book.AddFootnote(1, "Book1"));
        }

        [Test]
        public void Test_FindFootnoteMethodSholdReturnString()
        {
            this.book.AddFootnote(1, "Book1");
            this.book.AddFootnote(2, "Book2");
            this.book.AddFootnote(3, "Book3");

            string actulaFoodNote = "Footnote #2: Book2";
            string expectedFoodNote = this.book.FindFootnote(2);

            Assert.AreEqual(expectedFoodNote, actulaFoodNote);
        }

        [Test]
        public void Test_FindFootnoteMethodSholdThrowException_IfFoodnoteNotFound()
        {
            this.book.AddFootnote(1, "Book1");
            this.book.AddFootnote(2, "Book2");

            Assert.Throws<InvalidOperationException>(() => this.book.FindFootnote(3));
        }

        [Test]
        public void Test_AlterFootnoteMethodSholdThrowException_IfFoodnoteNotFound()
        {
            this.book.AddFootnote(1, "Book1");
            this.book.AddFootnote(2, "Book2");

            Assert.Throws<InvalidOperationException>(() => this.book.AlterFootnote(3, "newText"));
        }

        [Test]
        public void Test_AlterFootnoteMethodSholdAlterText()
        {
            this.book.AddFootnote(1, "Book1");
            this.book.AddFootnote(2, "Book2");
            this.book.AddFootnote(3, "Book3");

            this.book.AlterFootnote(2, "newText");

            string actulaFoodNote = "Footnote #2: newText";
            string expectedFoodNote = this.book.FindFootnote(2);

            Assert.AreEqual(actulaFoodNote, expectedFoodNote);
        }
    }
}