using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore_api_10_07_2021.Data;
using bookstore_api_10_07_2021.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookstore_api_10_07_2021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CategoryController : ControllerBase
    {
        private ApplicationDbContext context { get; set; }

        public CategoryController(ApplicationDbContext _context)
        {
            context = _context;
        }

        // GET: api/Category
        [HttpGet]

        public List<Category> Get()
        {
            return context.categories.ToList();
        }

        // GET: api/Category/1
        [HttpGet("{id}")]

        public Category Get(int id)
        {
            return context.categories.FirstOrDefault(c => c.CategoryID == id);
        }

        // POST: api/Category/4
        [HttpPost]

        public string Post([FromBody] Category _category)
        {
            Category category = context.categories.FirstOrDefault(c => c.CategoryName == _category.CategoryName);
            if (category == null)
            {
                context.categories.Add(_category);
                context.SaveChanges();
                return String.Format("Category with name of '{0}' was added", _category.CategoryName);
            }
            else
            {
                return String.Format("There is already a category with name of '{0}'", _category.CategoryName);
            }
        }

        // PUT: api/Category/4

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Category _category)
        {
            Category category = context.categories.Find(id);
            if (category == null)
            {
                return String.Format("There is no category with id of '{0}'", id);
            }
            else
            {
                context.Entry(category).CurrentValues.SetValues(_category); 
                context.SaveChanges();
                return String.Format("Category with id of '{0}' was successfully updated", id);
            }
        }

        // DELETE: api/Category/4
        [HttpDelete("{id}")]

        public string Delete(int id)
        {
            Category category = context.categories.Find(id);
            if (category == null)
            {
                return String.Format("There is no category with id of '{0}'", id);
            }
            else
            {
                context.categories.Remove(category);
                context.SaveChanges();
                return String.Format("Category with id of '{0}' was successfully deleted", id);
            }
        }

    }
}
