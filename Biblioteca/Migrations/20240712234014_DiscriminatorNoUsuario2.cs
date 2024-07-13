using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class DiscriminatorNoUsuario2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "Usuario"); // Setting the default value

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
