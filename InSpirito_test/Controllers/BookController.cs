using InSpirito_test.Interfaces;
using InSpirito_test.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InSpirito_test.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        IRepository _inMemoryRepository;

        public BookController(IRepository inMemoryRepository)
        {
            _inMemoryRepository = inMemoryRepository;
        }

        [HttpGet]
        [Route("getBooks")]
        public IQueryable<Book> GetAll()
        {
            return _inMemoryRepository.GetAll();
        }

        [HttpGet]
        [Route("getBooks/{id}")]
        public Book GetById(int id)
        {
            return _inMemoryRepository.GetById(id);
        }

        [HttpPost]
        [Route("addBook")]
        public IActionResult Add([FromBody]Book book)
        {
            try
            {
                _inMemoryRepository.Add(book);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _inMemoryRepository.Delete(id);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        public IActionResult Update([FromBody]Book book)
        {
            try
            {
                _inMemoryRepository.Update(book);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
