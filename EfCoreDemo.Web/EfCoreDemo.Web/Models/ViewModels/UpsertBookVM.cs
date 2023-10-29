using EfCoreDemo.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EfCoreDemo.Models.ViewModels
{
    public class UpsertBookVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> PublisherList { get; set; }
    }
}
