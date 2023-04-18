using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArenaQuest.Data;
using ArenaQuest.Models;

namespace ArenaQuest.Pages.Gamelogs
{
    public class EditModel : PageModel
    {
        private readonly ArenaQuest.Data.ArenaQuestContext _context;

        public EditModel(ArenaQuest.Data.ArenaQuestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gamelog Gamelog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Gamelog == null)
            {
                return NotFound();
            }

            var gamelog =  await _context.Gamelog.FirstOrDefaultAsync(m => m.Id == id);
            if (gamelog == null)
            {
                return NotFound();
            }
            Gamelog = gamelog;
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

            _context.Attach(Gamelog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamelogExists(Gamelog.Id))
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

        private bool GamelogExists(int id)
        {
          return (_context.Gamelog?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
