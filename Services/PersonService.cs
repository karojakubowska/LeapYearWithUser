using LeapYearWithUser.Data;
using LeapYearWithUser.Models;
using System.Security.Claims;

namespace LeapYearWithUser.Services
{
    public class PersonService: IPersonService
    {
        private readonly ApplicationDbContext _context;
        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddEntry(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public void AddEntry(ClaimsPrincipal currentUser, Person Person)
        {
            Person.NameLastname = Person.Name + " " + Person.LastName;
            Person.LeapYear = Person.RokPrzestepny();
            Person.Result = Person.CzyRokPrzestepny();
            DateTime date = DateTime.Now;
            Person.Date = date;

            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            Person.UserId = currentUserID.ToString();
            // People = _context.Person.ToList();
            _context.Person.Add(Person);
            _context.SaveChanges();
           
        }

        public IQueryable<Person> GetAllEntries()
        {
            return _context.Person;
        }

        public IQueryable<Person> GetEntriesFromToday()
        {
            return _context.Person.Where(p =>  p.Date.Value.Day == DateTime.Today.Day && p.Date.Value.Month == DateTime.Today.Month && p.Date.Value.Year == DateTime.Today.Year);
           // return GetAllEntries().Where(p => p.Date == DateTime.Today);
        }
       
    }
}
