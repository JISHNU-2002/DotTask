using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Entity.Migrations
{
    /// <inheritdoc />
    public partial class MenuPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuRolePermission",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRolePermission", x => new { x.RoleId, x.MenuId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuRolePermission");
        }
    }
}
