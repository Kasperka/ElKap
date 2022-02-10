#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ElKap.Data;

namespace ElKap.Pages.Person
{
    public class CreateModel : PageModel
    {
        private readonly ElKap.Data.ApplicationDbContext _context;

        public CreateModel(ElKap.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Persons Persons { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Persons.Add(Persons);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
