using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ArenaQuest.Data;
using ArenaQuest.Models;

namespace ArenaQuest.Pages.Gamelogs
{
    public class CreateModel : PageModel
    {
        private readonly ArenaQuest.Data.ArenaQuestContext _context;

        public CreateModel(ArenaQuest.Data.ArenaQuestContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Gamelog Gamelog { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Gamelog == null || Gamelog == null)
            {
                return Page();
            }

            _context.Gamelog.Add(Gamelog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
