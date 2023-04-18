using Microsoft.EntityFrameworkCore;
using ArenaQuest.Data;
using ArenaQuest.Models;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ArenaQuestContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ArenaQuestContext>>()))
        {
            if (context == null || context.Gamelog == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Gamelog.Any())
            {
                return;   // DB has been seeded
            }

            context.Gamelog.AddRange(
                new Gamelog
                {
                    Team1 = "Los Angeles Lakers",
                    Team2 = "Golden State Warriors",
                    Date = new DateTime(2023, 1, 15),
                    League = League.NBA,
                    Arena = "Staples Center",
                    Comments = "Exciting game with high scores.",
                    Rating = 4
                },

                new Gamelog
                {
                    Team1 = "Chicago Blackhawks",
                    Team2 = "Detroit Red Wings",
                    Date = new DateTime(2023, 3, 2),
                    League = League.NHL,
                    Arena = "United Center",
                    Comments = "Close game with a lot of penalties.",
                    Rating = 3
                },

                new Gamelog
                {
                    Team1 = "New England Patriots",
                    Team2 = "Kansas City Chiefs",
                    Date = new DateTime(2023, 9, 9),
                    League = League.NFL,
                    Arena = "Gillette Stadium",
                    Comments = "Thrilling game with a game-winning touchdown in the final minute.",
                    Rating = 5
                },

                new Gamelog
                {
                    Team1 = "Houston Rockets",
                    Team2 = "Dallas Mavericks",
                    Date = new DateTime(2023, 2, 28),
                    League = League.NBA,
                    Arena = "Toyota Center",
                    Comments = "Low-scoring game with poor shooting percentages.",
                    Rating = 2
                },
                new Gamelog
                {
                    Team1 = "New York Yankees",
                    Team2 = "Boston Red Sox",
                    Date = new DateTime(2023, 7, 18),
                    League = League.MLB,
                    Arena = "Yankee Stadium",
                    Comments = "Intense rivalry game with multiple home runs.",
                    Rating = 4
                }
            );
            context.SaveChanges();
        }
    }
}
