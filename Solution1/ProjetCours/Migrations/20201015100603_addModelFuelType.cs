using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetCours.Migrations
{
    public partial class addModelFuelType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Car");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Car",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuelTypeId",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fuel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuel", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_FuelTypeId",
                table: "Car",
                column: "FuelTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Fuel_FuelTypeId",
                table: "Car",
                column: "FuelTypeId",
                principalTable: "Fuel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Fuel_FuelTypeId",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Fuel");

            migrationBuilder.DropIndex(
                name: "IX_Car_FuelTypeId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "FuelTypeId",
                table: "Car");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Car",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "FuelType",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
