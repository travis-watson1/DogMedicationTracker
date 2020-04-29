using Microsoft.EntityFrameworkCore.Migrations;

namespace DogMedicationTracker.Migrations
{
    public partial class AddImageToDogsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Dogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Dogs");
        }
    }
}
