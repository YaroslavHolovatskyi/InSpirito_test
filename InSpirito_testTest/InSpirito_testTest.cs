
using InSpirito_test.Controllers;
using InSpirito_test.Interfaces;
using InSpirito_test.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace InSpirito_testTest
{
    [TestFixture]
    public class InSpirito_testTest
    {
        private BookController controller;
        private Mock<IRepository> mock;

        [SetUp]
        public void SetUp()
        {
            mock = new Mock<IRepository>();
            controller = new BookController(mock.Object);
        }

        [Test]
        public void GetAllTest()
        {
            //arrange
            SetUp();
            mock.Setup(x => x.GetAll()).Returns(new List<Book>().AsQueryable());

            //act
            var result = controller.GetAll();

            //assert
            mock.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void AddTest()
        {
            //arrange
            SetUp();
            Book book = new Book();
            mock.Setup(x => x.Add(book));

            //act
            var result = controller.Add(book);

            //assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public void DeleteTest()
        {
            //Arrange
            SetUp();
            Book book = new Book();
            mock.Setup(x => x.Add(book));

            controller.Add(book);
            //Act
            var result = controller.Delete(book.Id);
            //Assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public void UpdateTest()
        {
            //Arrange
            
            Book book = new Book { Title = "Test", Author = "Test" };
            mock.Setup(a => a.Add(book));
            string exp = "111";
            book.Title = exp;
            book.Author = exp;
            mock.Setup(a => a.Update(book));


            var result = controller.Update(book);


            Assert.IsInstanceOf<OkResult>(result);
            Assert.AreEqual(exp, book.Title);
            Assert.AreEqual(exp, book.Author);
        }

    }
}
