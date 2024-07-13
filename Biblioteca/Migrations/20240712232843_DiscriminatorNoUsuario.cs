using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class DiscriminatorNoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cf52166-09e7-4fc8-9d9b-98a5e9d6a43d", "AQAAAAIAAYagAAAAEIwQSHvgi4r6N1ddlClESJcg5NT09SbVS4JCiM6mPdT07fWnXIwWFdDicCv94LyVNg==", "11c48ff8-14b5-4f18-9f2f-aa9e6d8aba4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc7dcf90-e5ed-4cf7-9a83-fd3ce3838cb0", "AQAAAAIAAYagAAAAEHrZUA6jMhRBzI4yvXxz9T/6fSvAfHXdo4Nc2qEkT1adPNpenyaxmuKgoyMgRHlfBQ==", "3ee53213-2a51-45b6-9f9f-cc81affe9fc1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
