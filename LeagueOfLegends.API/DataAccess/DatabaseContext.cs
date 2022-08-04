using LeagueOfLegends.Scrapper.Model;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfLegends.API.DataAccess;

public class DatabaseContext: DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

    public DbSet<PatchNoteModel> PatchNoteModels { get; set; }
}