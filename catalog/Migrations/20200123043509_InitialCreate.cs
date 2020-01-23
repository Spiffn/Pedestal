using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Pedestal.Catalog.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "modeldydoo_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Modeldydoo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    UploaderId = table.Column<int>(nullable: false),
                    FileUri = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Tags = table.Column<string>(maxLength: 256, nullable: false),
                    UploadDateUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeldydoo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modeldydoo");

            migrationBuilder.DropSequence(
                name: "modeldydoo_hilo");
        }
    }
}
