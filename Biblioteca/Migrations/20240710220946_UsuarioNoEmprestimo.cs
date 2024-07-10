using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioNoEmprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Emprestimos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e15fd18e-c4d4-4f1d-92d3-0136046f2279", "AQAAAAIAAYagAAAAED08pCIangiUFbmBdoPPSyZzcm8WXWUKp91TRPKkvf8jnl543E6O06357vM0INA33A==", "62b2aab8-6bec-45b3-9a1d-090705f1b94a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31d685f5-2602-43f2-b171-72367b7c5870", "AQAAAAIAAYagAAAAEFxG3E4bYwIWzXwqGEHvkiLXs4p9t+VYVQYARwplaHdlFxFkoNRpNSONHbNQX9k8pQ==", "db0f3559-d03d-4ac0-914f-da4ac9db8291" });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_UsuarioId",
                table: "Emprestimos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_AspNetUsers_UsuarioId",
                table: "Emprestimos",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_AspNetUsers_UsuarioId",
                table: "Emprestimos");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimos_UsuarioId",
                table: "Emprestimos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Emprestimos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "026a8e56-031b-47af-ac19-c00dcff6c639", "AQAAAAIAAYagAAAAEKDSNM1t4asIPg2LAghOKwaz+R8iPOxu2dTyF8DJlyVSxe755LhmjfuWEEg9AI+z0A==", "f0b3757d-3c93-4da4-9621-072dead1d225" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f322490-b099-42f6-a4c8-8e9723c2fe61", "AQAAAAIAAYagAAAAEPjilHAvhwR6fi03XETBhGNpVp1JLwn2m763C/HXuEXWv3Vm5SxpVuckoteRQKlLsg==", "ade6607a-e4dc-4fdb-b2e0-f6029a7ff265" });
        }
    }
}
