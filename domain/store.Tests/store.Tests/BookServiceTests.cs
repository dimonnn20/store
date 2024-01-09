﻿using Moq;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Tests
{
    public class BookServiceTests
    {
        //[Fact]
        //public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        //{
        //    var bookRepositoryStub = new Mock<IBookRepository>();
        //    bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>())).Returns(new[] { new Book(1,"","","")});

        //    bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>())).Returns(new[] { new Book(2, "", "", "") });

        //    var bookService = new BookService(bookRepositoryStub.Object);
        //    var validIsbn = "ISBN 12345-67890";
        //    var actual = bookService.GetAllByQuery(validIsbn);
        //    Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        //}

        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            const int idOfIsbnSearch = 1;
            const int idOfAuthorSearch = 2;
            var bookRepository = new StubBookRepository();
            bookRepository.ResultOfGetAllByIsbn = new[] { new Book(idOfIsbnSearch, "", "", "") };
            bookRepository.ResultOfGetAllByTitleOrAuthor = new[] { new Book(idOfAuthorSearch, "", "", "") };
            var bookService = new BookService(bookRepository);
            var books = bookService.GetAllByQuery("ISBN 12345-67890");
            Assert.Collection(books, book => Assert.Equal(idOfIsbnSearch, book.Id));

        }
    }
}
