using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankPOS.Migrations
{
    /// <inheritdoc />
    public partial class TransactionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamP",
                table: "Transactions",
                newName: "TimeStamp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Transactions",
                newName: "TimeStamP");
        }
    }
}
