using EfCoreDemo.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EfCoreDemo.Models.ViewModels
{
    public class AuthorBookVM
    {
        public Book Book { get; set; }
        public AuthorBookRelation AuthorBookRelation { get; set; }

        public IEnumerable<AuthorBookRelation> AuthorBookList { get; set; }
        public IEnumerable<SelectListItem> AuthorList { get; set; }
    }
}
