using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace IPReport.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class IPForensicsReportTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IPR$IPForensicsReports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AppUser_FK = table.Column<long>(type: "bigint", nullable: false),
                    IPAddress = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    AbuseConfidenceScore = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    TotalReports = table.Column<long>(type: "bigint", nullable: false),
                    LastReportedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Continent = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Region = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsHosting = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsMobile = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsProxy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsTor = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPR$IPForensicsReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IPR$IPForensicsReports_IPR$AppUsers_AppUser_FK",
                        column: x => x.AppUser_FK,
                        principalTable: "IPR$AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_IPR$IPForensicsReports_AppUser_FK_CreatedDate",
                table: "IPR$IPForensicsReports",
                columns: new[] { "AppUser_FK", "CreatedDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPR$IPForensicsReports");
        }
    }
}
