using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LIR.DAL.Migrations
{
    public partial class initialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumerProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasicSalary = table.Column<double>(type: "float", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RetirementSetups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuaranteedIssue = table.Column<double>(type: "float", nullable: false),
                    MaxAgeLimit = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    MinAgeLimit = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    MinimumRange = table.Column<int>(type: "int", nullable: false),
                    MaximumRange = table.Column<int>(type: "int", nullable: false),
                    Increments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetirementSetups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerBenefitResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Multiple = table.Column<int>(type: "int", nullable: false),
                    BenefitsAmountQuotation = table.Column<double>(type: "float", nullable: false),
                    PendedAmount = table.Column<double>(type: "float", nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerBenefitResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerBenefitResults_ConsumerProfiles_ConsumerProfileId",
                        column: x => x.ConsumerProfileId,
                        principalTable: "ConsumerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerBenefitResults_ConsumerProfileId",
                table: "ConsumerBenefitResults",
                column: "ConsumerProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumerBenefitResults");

            migrationBuilder.DropTable(
                name: "RetirementSetups");

            migrationBuilder.DropTable(
                name: "ConsumerProfiles");
        }
    }
}
