using LeapYearWithUser.Data;
using LeapYearWithUser.Models;
using LeapYearWithUser.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeapYearWithUser.Pages
{
    [Authorize]
    public class LastSearched : PageModel
    {
        public Person Person { get; set; }
        private readonly ApplicationDbContext _context;
        public List<Person> Osoby = new List<Person>();
        private readonly IPersonService _personService;
        public IQueryable<Person> Records { get; set; }

        public LastSearched(ApplicationDbContext context,IPersonService personService)
        {
            _context = context;
            _personService = personService;
        }
        public void OnGet()
        {
            Records = _personService.GetAllEntries();
            /*var top20 = _context.Person.OrderByDescending(person => person.Date).Take(20);
            Osoby = top20.ToList();*/
        }
    }
}
