using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HumanoTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único de Entidad.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Número de Documento de Identidad."),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nombre de Persona."),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Edad de Persona.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                },
                comment: "Persona");

            migrationBuilder.CreateTable(
                name: "PersonContactType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único de Entidad.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nombre."),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false, comment: "Descripcion.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContactType", x => x.Id);
                },
                comment: "Entidad de Información de Tipo de Contacto Persona.");

            migrationBuilder.CreateTable(
                name: "PersonContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único de Entidad.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonContactTypeId = table.Column<int>(type: "int", nullable: false, comment: "Tipo Contacto Persona"),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nombre de Contacto."),
                    Data = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Dato de Contacto"),
                    IsMainContact = table.Column<bool>(type: "bit", nullable: false, comment: "Identifica si es el Contacto Principal del Cliente, True = Activo or False = Inactivo."),
                    PersonId = table.Column<int>(type: "int", nullable: false, comment: "Identificador de Persona.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonContact_PersonContactType_PersonContactTypeId",
                        column: x => x.PersonContactTypeId,
                        principalTable: "PersonContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonContact_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Contactos Persona");

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Age", "IdentityNumber", "Name" },
                values: new object[,]
                {
                    { 1, 1, "957709015", "Person 1" },
                    { 2, 2, "685407361", "Person 2" },
                    { 3, 3, "439924747", "Person 3" },
                    { 4, 4, "558433187", "Person 4" },
                    { 5, 5, "457098325", "Person 5" },
                    { 6, 6, "522865059", "Person 6" },
                    { 7, 7, "818066775", "Person 7" },
                    { 8, 8, "363201467", "Person 8" },
                    { 9, 9, "979061742", "Person 9" }
                });

            migrationBuilder.InsertData(
                table: "PersonContactType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description Of Contact Type 1", "Contact Type 1" },
                    { 2, "Description Of Contact Type 2", "Contact Type 2" },
                    { 3, "Description Of Contact Type 3", "Contact Type 3" },
                    { 4, "Description Of Contact Type 4", "Contact Type 4" },
                    { 5, "Description Of Contact Type 5", "Contact Type 5" },
                    { 6, "Description Of Contact Type 6", "Contact Type 6" },
                    { 7, "Description Of Contact Type 7", "Contact Type 7" },
                    { 8, "Description Of Contact Type 8", "Contact Type 8" },
                    { 9, "Description Of Contact Type 9", "Contact Type 9" }
                });

            migrationBuilder.InsertData(
                table: "PersonContact",
                columns: new[] { "Id", "ContactName", "Data", "IsMainContact", "PersonContactTypeId", "PersonId" },
                values: new object[,]
                {
                    { 1, "Person 1", "Informacion de Contacto 1", false, 1, 1 },
                    { 2, "Person 2", "Informacion de Contacto 2", false, 2, 2 },
                    { 3, "Person 3", "Informacion de Contacto 3", false, 3, 3 },
                    { 4, "Person 4", "Informacion de Contacto 4", false, 4, 4 },
                    { 5, "Person 5", "Informacion de Contacto 5", false, 5, 5 },
                    { 6, "Person 6", "Informacion de Contacto 6", false, 6, 6 },
                    { 7, "Person 7", "Informacion de Contacto 7", false, 7, 7 },
                    { 8, "Person 8", "Informacion de Contacto 8", false, 8, 8 },
                    { 9, "Person 9", "Informacion de Contacto 9", false, 9, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdentityNumber",
                table: "Person",
                column: "IdentityNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonContact_Id",
                table: "PersonContact",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContact_PersonContactTypeId",
                table: "PersonContact",
                column: "PersonContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContact_PersonId",
                table: "PersonContact",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContactType_Name",
                table: "PersonContactType",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonContact");

            migrationBuilder.DropTable(
                name: "PersonContactType");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
