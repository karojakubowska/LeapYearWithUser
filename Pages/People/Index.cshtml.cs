#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LeapYearWithUser.Data;
using LeapYearWithUser.Models;
using Microsoft.AspNetCore.Authorization;

namespace LeapYearWithUser.Pages.People
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly LeapYearWithUser.Data.ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = await _context.Person.ToListAsync();
        }
    }
}
