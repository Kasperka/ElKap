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
    public class DetailsModel : PageModel
    {
        private readonly ElKap.Data.ApplicationDbContext _context;

        public DetailsModel(ElKap.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Persons Persons { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Persons = await _context.Persons.FirstOrDefaultAsync(m => m.Id == id);

            if (Persons == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
