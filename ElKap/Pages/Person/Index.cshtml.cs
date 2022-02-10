#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ElKap.Data;

namespace ElKap.Pages.Person
{
    public class IndexModel : PageModel
    {
        private readonly ElKap.Data.ApplicationDbContext _context;

        public IndexModel(ElKap.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Persons> Persons { get;set; }

        public async Task OnGetAsync()
        {
            Persons = await _context.Persons.ToListAsync();
        }
    }
}
