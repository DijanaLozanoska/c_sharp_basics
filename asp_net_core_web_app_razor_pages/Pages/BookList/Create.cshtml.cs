using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_core_web_app_razor_pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_net_core_web_app_razor_pages.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel (ApplicationDbContext db)
        {
            _db = db;
        }


        [BindProperty]
        public Book Book { get; set; }


        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");

            }
            else
            {
                return Page();
            }
        }
    }
}