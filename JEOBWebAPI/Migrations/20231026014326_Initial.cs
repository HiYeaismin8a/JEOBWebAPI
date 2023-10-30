using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JEOBWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    IdAlumno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.IdAlumno);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    IdMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.IdMateria);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoMateria",
                columns: table => new
                {
                    AlumnosIdAlumno = table.Column<int>(type: "int", nullable: false),
                    MateriasIdMateria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoMateria", x => new { x.AlumnosIdAlumno, x.MateriasIdMateria });
                    table.ForeignKey(
                        name: "FK_AlumnoMateria_Alumnos_AlumnosIdAlumno",
                        column: x => x.AlumnosIdAlumno,
                        principalTable: "Alumnos",
                        principalColumn: "IdAlumno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoMateria_Materias_MateriasIdMateria",
                        column: x => x.MateriasIdMateria,
                        principalTable: "Materias",
                        principalColumn: "IdMateria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoMateria_MateriasIdMateria",
                table: "AlumnoMateria",
                column: "MateriasIdMateria");
            /*var command = @"CREATE PROCEDURE GetTotalCost
	                    @alumno AS INT
                        AS
                        BEGIN
	                        SET NOCOUNT ON;
	                        DECLARE @total AS DECIMAL;

	                        SELECT @total= SUM(m.Costo) 
		                        FROM Alumnos a
		                        INNER JOIN AlumnoMateria am
		                        ON am.AlumnosIdAlumno = a.IdAlumno
		                        INNER JOIN Materias m
		                        ON m.IdMateria = am.MateriasIdMateria
		                        WHERE a.IdAlumno = @alumno
	
                        END
                        GO";
            migrationBuilder.Sql(command);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoMateria");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Materias");
            /*var command = "DROP PROCEDURE GetTotalCost";
            migrationBuilder.Sql(command);*/
        }
    }
}
