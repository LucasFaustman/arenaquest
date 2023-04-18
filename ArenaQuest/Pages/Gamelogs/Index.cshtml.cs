using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArenaQuest.Data;
using ArenaQuest.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ArenaQuest.Pages.Gamelogs
{
    public class IndexModel : PageModel
    {
        private readonly ArenaQuest.Data.ArenaQuestContext _context;

        public IndexModel(ArenaQuest.Data.ArenaQuestContext context)
        {
            _context = context;
        }

        public IList<Gamelog> Gamelog { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Arenas { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? GamelogArena{ get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> arenaQuery = from m in _context.Gamelog
                                            orderby m.Arena
                                            select m.Arena;
            var gamelogs = from m in _context.Gamelog
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                gamelogs = gamelogs.Where(s => s.Team1 != null && s.Team1.Contains(SearchString) ||
                               s.Team2 != null && s.Team2.Contains(SearchString));

            }

            if (!string.IsNullOrEmpty(GamelogArena))
            {
                gamelogs = gamelogs.Where(x => x.Arena == GamelogArena);
            }
            Arenas = new SelectList(await arenaQuery.Distinct().ToListAsync());

            Gamelog = await gamelogs.ToListAsync();
        }
    }
}
