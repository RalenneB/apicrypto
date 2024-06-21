using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apicrypto.Migrations
{
    /// <inheritdoc />
    public partial class InitDca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DcaInvestmentId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DcaInvestments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<int>(type: "int", nullable: false),
                    CryptoType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvestedAmount = table.Column<int>(type: "int", nullable: false),
                    CryptoPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcaInvestments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DcaInvestmentId",
                table: "Comments",
                column: "DcaInvestmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_DcaInvestments_DcaInvestmentId",
                table: "Comments",
                column: "DcaInvestmentId",
                principalTable: "DcaInvestments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_DcaInvestments_DcaInvestmentId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "DcaInvestments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_DcaInvestmentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DcaInvestmentId",
                table: "Comments");
        }
    }
}
