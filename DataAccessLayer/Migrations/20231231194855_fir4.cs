using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class fir4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personeles",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeles", x => x.PersonelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personeles");
        }
    }
}
