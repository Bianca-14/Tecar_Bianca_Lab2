using Microsoft.AspNetCore.Identity.UI.Services;

namespace Tecar_Bianca_Lab2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers {  get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
