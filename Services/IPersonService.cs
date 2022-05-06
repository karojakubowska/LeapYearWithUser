using LeapYearWithUser.Models;
using System.Security.Claims;

namespace LeapYearWithUser.Services
{
    public interface IPersonService
    {
        public void AddEntry(Person person);
        public void AddEntry(ClaimsPrincipal currentUser,Person person);
        public IQueryable<Person> GetAllEntries();
        public IQueryable<Person> GetEntriesFromToday();
    }
}
