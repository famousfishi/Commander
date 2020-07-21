using Microsoft.EntityFrameworkCore.Migrations;

namespace Commander.Migrations
{
    public partial class PopulatCommandsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Commands(HowTo, Line, Platform) Values('How to make migrations', 'add-migration InitialMigration', 'EF Core')");
            migrationBuilder.Sql("INSERT INTO Commands(HowTo, Line, Platform) Values('How to code', 'be consistent', 'Determination')");
            migrationBuilder.Sql("INSERT INTO Commands(HowTo, Line, Platform) Values('How to design', 'be zealous', 'Photoshop')");
            migrationBuilder.Sql("INSERT INTO Commands(HowTo, Line, Platform) Values('Programming Practices', 'read books', 'Standard programming books')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
