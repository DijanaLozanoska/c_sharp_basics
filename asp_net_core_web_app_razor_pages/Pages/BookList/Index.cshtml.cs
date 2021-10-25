using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_core_web_app_razor_pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace asp_net_core_web_app_razor_pages.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Book> Books { get; set; }


        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
