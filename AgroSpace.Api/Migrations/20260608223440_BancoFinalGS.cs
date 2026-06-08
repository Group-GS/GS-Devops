using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroSpace.Api.Migrations
{
    /// <inheritdoc />
    public partial class BancoFinalGS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    id_local = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    cidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    id_bioma = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.id_local);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    id_sensor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    tipo_sensor = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    status = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    id_local = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.id_sensor);
                    table.ForeignKey(
                        name: "FK_Sensor_Locais_id_local",
                        column: x => x.id_local,
                        principalTable: "Locais",
                        principalColumn: "id_local",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_id_local",
                table: "Sensor",
                column: "id_local");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "Locais");
        }
    }
}
