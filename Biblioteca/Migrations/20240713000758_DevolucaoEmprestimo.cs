using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class DevolucaoEmprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "devolvido",
                table: "Emprestimos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32b05586-5f40-46e4-9bde-b13d85f276dc", "AQAAAAIAAYagAAAAEMr9GbPZw+YSD4qEtV7Kum4UQYM+hGMF9jJdfY3paci4YvpTHj1VI8rb6Cgo42kW7A==", "f71ef3f8-9a27-4d3a-b442-92b4c68270d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c124a8b-174e-4d4f-8744-5d9c1ca971fc", "AQAAAAIAAYagAAAAEAOKfS63HHSxlkfHt2HghVJ2H0+bRnxLWVb4O7+3+XYEFyiloFAH16cb407uodETZw==", "fcd12aff-324a-429f-93b3-49c227e21d0e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "devolvido",
                table: "Emprestimos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e2e9b95-dd25-44ce-abc7-05c63cab78eb", "AQAAAAIAAYagAAAAELA7I1JKjxcFIMyOk+k+ZbE8TH/vFb+mJGhrFuXajIo63jw6gc91aBGq6rzRfqB3Tw==", "45552680-2124-45cc-9c54-f259b0695c43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a8fccd6-c712-4727-a6c8-19ef4dc2aedb", "AQAAAAIAAYagAAAAEA0MAyLntzuGuLA+3ZAGHyR/UWJDvLWoV8OktbO4PEjFzGJM8OA9R2BcLyvHlQ5slg==", "30220aa8-cf66-4769-b0f2-983a4d6be385" });
        }
    }
}
