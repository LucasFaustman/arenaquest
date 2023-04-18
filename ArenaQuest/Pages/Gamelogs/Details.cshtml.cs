using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArenaQuest.Data;
using ArenaQuest.Models;

namespace ArenaQuest.Pages.Gamelogs
{
    public class DetailsModel : PageModel
    {
        private readonly ArenaQuest.Data.ArenaQuestContext _context;

        public DetailsModel(ArenaQuest.Data.ArenaQuestContext context)
        {
            _context = context;
        }

      public Gamelog Gamelog { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Gamelog == null)
            {
                return NotFound();
            }

            var gamelog = await _context.Gamelog.FirstOrDefaultAsync(m => m.Id == id);
            if (gamelog == null)
            {
                return NotFound();
            }
            else 
            {
                Gamelog = gamelog;
            }
            return Page();
        }
    }
}
