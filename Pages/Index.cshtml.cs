using LeapYearWithUser.Data;
using LeapYearWithUser.Models;
using LeapYearWithUser.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Claims;

namespace LeapYearWithUser.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Person Person { get; set; }
        public List<Person> People = new List<Person>();
        private readonly ApplicationDbContext _context;
        private readonly IPersonService _personService;
        public IQueryable<Person> Records { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, IPersonService personService)
        {
            _logger = logger;
            _context = context;
            _personService = personService;
        }

        public void OnGet()
        {
            Records = _personService.GetEntriesFromToday();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TempData["Results"] = Person.CzyRokPrzestepny();
            ClaimsPrincipal currentUser = this.User;
            _personService.AddEntry(currentUser, Person);
            Records = _personService.GetEntriesFromToday();
            return Page(); ;
            /*  if (HttpContext.Session.GetString("DataList") == null)
              {
                  People.Add(Person);
                  HttpContext.Session.SetString("DataList", JsonConvert.SerializeObject(People));
              }
              else
              {
                  var SessionList = HttpContext.Session.GetString("DataList");
                  People = JsonConvert.DeserializeObject<List<Person>>(SessionList);
                  People.Add(Person);
                  HttpContext.Session.SetString("DataList", JsonConvert.SerializeObject(People));
              }*/

            // 
            /* Person.NameLastname = Person.Name + " " + Person.LastName;
             Person.LeapYear = Person.RokPrzestepny();
             Person.Result = Person.CzyRokPrzestepny();
             DateTime date = DateTime.Now;
             Person.Date = date;
             //ClaimsPrincipal currentUser = this.User;
             var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
             Person.UserId = currentUserID.ToString();
             // People = _context.Person.ToList();

             _context.Person.Add(Person);
             _context.SaveChanges();*/

        }
    }
    
}