using InSpirito_test.Interfaces;
using InSpirito_test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InSpirito_test.Repositories
{
    public class InMemoryRepository : IRepository
    {
        private List<Book> books = new List<Book>();
        private int lastBookId = 2;
        public InMemoryRepository()
        {
            books.Add(new Book { Id = 0, Title = "Harry Potter", Author = "Joanne Rowling" });
            books.Add(new Book { Id = 1, Title = "Schindler's list", Author = "Thomas Keneally" });
            books.Add(new Book { Id = 2, Title = "A Song of Ice and Fire", Author = "George R. R. Martin" });
        }

        public IQueryable<Book> GetAll()
        {
            return books.AsQueryable();
        }
        public Book GetById(int id)
        {
            return books.Find(x => x.Id == id);
        }
        public void Delete(int id)
        {
            Book item = books.Find(x => x.Id == id);
            books.Remove(item);
        }
        public void Add(Book entity)
        {
            entity.Id = ++lastBookId;
            books.Add(entity);
        }
        public void Update(Book entity)
        {

            Book obj = books.FirstOrDefault(x => x.Id == entity.Id);

            obj.Title = entity.Title;
            obj.Author = entity.Author;
            
        }
    }
}
