using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueOfLegends.API.DataAccess.Migrations
{
    public partial class summonerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SummonerResponses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<string>(type: "text", nullable: false),
                    Puuid = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProfileIconId = table.Column<long>(type: "bigint", nullable: false),
                    RevisionDate = table.Column<long>(type: "bigint", nullable: false),
                    SummonerLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummonerResponses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummonerResponses");
        }
    }
}
