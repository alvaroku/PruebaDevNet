using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class datauser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Correo", "Direccion", "HashedPassword", "Nombre", "RolId" },
                values: new object[] { 1, "Kú", "alvaro.ku.dev@gmail.com", "Dirección de ejemplo", "$2a$11$enh.jL6h61wI53GMt.adBOSlZiAopheQRU2ZR4BdlBX8.zYAaz5r.", "Alvaro", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
