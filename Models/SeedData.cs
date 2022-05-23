using Microsoft.EntityFrameworkCore;

namespace NoteTaker.Models;

public static class SeedData
{
    public static void SeedDatabase(DataContext context)
    {
        context.Database.Migrate();
        if (!context.Notes.Any())
        {
            context.Notes.AddRange(
                new Note { Title = "My first title", Body = "This is my first awesome note" },
                new Note { Title = "My second title", Body = "This is my second awesome note" },
                new Note { Title = "My third title", Body = "This is my third awesome note" },
                new Note { Title = "My fourth title", Body = "This is my fourth awesome note" },
                new Note { Title = "My fifth title", Body = "This is my fifth awesome note" }
            );
            context.SaveChanges();
        }
    }
}