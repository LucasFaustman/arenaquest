using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArenaQuest.Models;

namespace ArenaQuest.Data
{
    public class ArenaQuestContext : DbContext
    {
        public ArenaQuestContext (DbContextOptions<ArenaQuestContext> options)
            : base(options)
        {
        }

        public DbSet<ArenaQuest.Models.Gamelog> Gamelog { get; set; } = default!;
    }
}
