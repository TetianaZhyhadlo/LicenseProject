using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LicenseProject.Migrations
{
    public partial class ALL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTeams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PeopleQuantity = table.Column<string>(nullable: true),
                    SoftID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTeams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountName = table.Column<string>(nullable: true),
                    Percantage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LicenseTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Softs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    DevTeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Softs_DeveloperTeams_DevTeamID",
                        column: x => x.DevTeamID,
                        principalTable: "DeveloperTeams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moduls",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SoftID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moduls", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Moduls_Softs_SoftID",
                        column: x => x.SoftID,
                        principalTable: "Softs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sellings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceNumber = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    SoftID = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    LicenseTypeID = table.Column<int>(nullable: false),
                    DiscountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sellings_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellings_Discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellings_LicenseTypes_LicenseTypeID",
                        column: x => x.LicenseTypeID,
                        principalTable: "LicenseTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellings_Softs_SoftID",
                        column: x => x.SoftID,
                        principalTable: "Softs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moduls_SoftID",
                table: "Moduls",
                column: "SoftID");

            migrationBuilder.CreateIndex(
                name: "IX_Sellings_CustomerID",
                table: "Sellings",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Sellings_DiscountID",
                table: "Sellings",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_Sellings_LicenseTypeID",
                table: "Sellings",
                column: "LicenseTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sellings_SoftID",
                table: "Sellings",
                column: "SoftID");

            migrationBuilder.CreateIndex(
                name: "IX_Softs_DevTeamID",
                table: "Softs",
                column: "DevTeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moduls");

            migrationBuilder.DropTable(
                name: "Sellings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "LicenseTypes");

            migrationBuilder.DropTable(
                name: "Softs");

            migrationBuilder.DropTable(
                name: "DeveloperTeams");
        }
    }
}
