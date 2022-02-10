#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElKap.Data;

namespace ElKap.Pages.Person
{
    public class EditModel : PageModel
    {
        private readonly ElKap.Data.ApplicationDbContext _context;

        public EditModel(ElKap.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Persons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonsExists(Persons.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PersonsExists(string id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
