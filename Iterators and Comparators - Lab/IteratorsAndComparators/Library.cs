using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIdex;

            public LibraryIterator(List<Book> books)
            {
                
                this.books = books;
                this.books.Sort();
                this.Reset();
            }

            public Book Current => this.books[this.currentIdex];

            object IEnumerator.Current => this.Current;

            public void Dispose(){}

            public bool MoveNext()
            {
                return ++this.currentIdex < this.books.Count;
            }

            public void Reset()
            {
                this.currentIdex = -1;
            }
        }
    }
}
