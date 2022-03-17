using ElKap.Domain.Party;
using ElKap.Facade.Party;
using ElKap.Infra.Party;
using ElKap.SolutionData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElKap.Pages.Person
{
    //TODO To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    //TODO To protect from overposting attacks, enable the specific properties you want to bind to.
    //TODO For more details, see https://aka.ms/RazorPagesCRUD.
    public class PersonsPage : PageModel
	{
        private readonly IPersonsRepo repo;

        [BindProperty] public PersonView Item { get; set; }
        
        private async Task<PersonView> getPerson(string id) => new PersonViewFactory().Create(await repo.GetAsync(id));

        public IList<PersonView> PersonsList { get; set; }
        //Create
        public PersonsPage(ElKapDb c) => repo = new PersonsRepo(c, c.Persons);

        public IActionResult OnGet() => Page();

        public string ItemId => Item?.Id ?? string.Empty;

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();

            await repo.AddAsync(new PersonViewFactory().Create(Item));

            return RedirectToPage("./Index", "Index");
        }
        //Delete
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Item = await getPerson(id);
            return Item == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        //Details
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Item = await getPerson(id);
            return Item == null ? NotFound() : Page();
        }
        //Edit
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Item = await getPerson(id);
            return Item == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();

            var obj = new PersonViewFactory().Create(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync()
        {

            var list = await repo.GetAsync();
            PersonsList = new List<PersonView>();

            foreach (var obj in list)
            {
                var v = new PersonViewFactory().Create(obj);
                PersonsList.Add(v);
            }
            return Page();
        }
    }
}
