using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tecar_Bianca_Lab2.Data;
using Tecar_Bianca_Lab2.Models;

namespace Tecar_Bianca_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Tecar_Bianca_Lab2.Data.Tecar_Bianca_Lab2Context _context;

        public IndexModel(Tecar_Bianca_Lab2.Data.Tecar_Bianca_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;



        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // Include the Publisher information when fetching Books
            Book = await _context.Book
                .Include(b => b.Publisher)  // This will include the Publisher data related to each Book
                .ToListAsync();
        }
    }
}
