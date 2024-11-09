using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tecar_Bianca_Lab2.Data;
using Tecar_Bianca_Lab2.Models;
using Tecar_Bianca_Lab2.Models.ViewModels;

namespace Tecar_Bianca_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Tecar_Bianca_Lab2.Data.Tecar_Bianca_Lab2Context _context;

        public IndexModel(Tecar_Bianca_Lab2.Data.Tecar_Bianca_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get; set; } = default!;
        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }

        // This method handles both the Publisher and Book data retrieval
        public async Task OnGetAsync(int? id, int? bookID)
        {
            PublisherData = new PublisherIndexData();

            // Fetch the list of publishers, including related books, ordered by PublisherName
            PublisherData.Publishers = await _context.Publisher
                .Include(i => i.Books)
                .OrderBy(i => i.PublisherName)
                .ToListAsync();

            // If an ID is provided, filter the selected publisher and load the related books
            if (id != null)
            {
                PublisherID = id.Value;
                Publisher publisher = PublisherData.Publishers
                    .Where(i => i.ID == id.Value)
                    .Single();

                PublisherData.Books = publisher.Books;
            }
        }
    }
}
