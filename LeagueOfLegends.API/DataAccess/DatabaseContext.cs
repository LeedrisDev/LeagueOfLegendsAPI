namespace LeagueOfLegends.API.DataAccess;

using Microsoft.EntityFrameworkCore;
using Scrapper.Model;
using Models.Response;

/// <summary>
/// Class to manage the database context.
/// </summary>
public class DatabaseContext: DbContext
{
    /// <summary>
    /// Context for patch notes.
    /// </summary>
    public DbSet<PatchNoteModel> PatchNoteModels { get; set; } = null!;
    
    /// <summary>
    /// Context for summoner data.
    /// </summary>
    public DbSet<SummonerResponse> SummonerResponses { get; set; } = null!;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="options"></param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
}