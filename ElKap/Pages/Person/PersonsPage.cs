using System;
using Domain.Party;
using Facade.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ElKap.Pages.Person
{
    //TODO To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    //TODO To protect from overposting attacks, enable the specific properties you want to bind to.
    //TODO For more details, see https://aka.ms/RazorPagesCRUD.
    public class PersonsPage : PageModel
	{
        private readonly ElKap.Data.ApplicationDbContext context;

        [BindProperty] public PersonView Persons { get; set; }
        
        private async Task<PersonView> getPerson(string id)
        {
            if (id == null) return null;
            var d = await context.Persons.FirstOrDefaultAsync(m => m.Id == id);
            if (d == null) return null;
            return new PersonViewFactory().Create(new Domain.Party.Person(d));
        }

        public IList<PersonView> PersonsList { get; set; }
        //Create
        public PersonsPage(ElKap.Data.ApplicationDbContext c) => context = c;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new PersonViewFactory().Create(Persons).Data;

            context.Persons.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        //Delete
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Persons = await getPerson(id);
            return Persons == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Persons.FindAsync(id);

            if (d != null)
            {
                context.Persons.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        //Details
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Persons = await getPerson(id);
            return Persons == null ? NotFound() : Page();
        }
        //Edit
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Persons = await getPerson(id);
            return Persons == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new PersonViewFactory().Create(Persons).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
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

            return RedirectToPage("./Index", "Index");
        }

        private bool PersonsExists(string id)
        {
            return context.Persons.Any(e => e.Id == id);
        }

        public async Task OnGetIndexAsync()
        {

            var list = await context.Persons.ToListAsync();
            PersonsList = new List<PersonView>();

            foreach (var p in list)
            {
                var v = new PersonViewFactory().Create(new Domain.Party.Person(p));
                PersonsList.Add(v);
            }
        }
    }
}
