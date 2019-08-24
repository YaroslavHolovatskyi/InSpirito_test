using InSpirito_test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InSpirito_test.Interfaces
{
    public interface IRepository
    {
        IQueryable<Book> GetAll();
        Book GetById(int id);
        void Add(Book entity);
        void Delete(int id);
        void Update(Book entity);
    }
}
