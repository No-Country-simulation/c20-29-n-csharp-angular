using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Refugios",
                columns: table => new
                {
                    IdRefugio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    _TipoOrganizacion = table.Column<int>(type: "int", nullable: false),
                    UbicacionFisica = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AñoFundacion = table.Column<int>(type: "int", nullable: true),
                    DatosContacto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentoLegal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FotosRefugio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VideoPresentacion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RedesSociales = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TestimoniosReferencias = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refugios", x => x.IdRefugio);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contraseña = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Perfil = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    IdPost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoPost = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FotoVideo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Categoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    TipoProveedor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroIdentificacionFiscal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RedesSociales = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdRefugio = table.Column<int>(type: "int", nullable: true),
                    IdRefugioNavigationIdRefugio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.IdPost);
                    table.ForeignKey(
                        name: "FK_Post_Refugios_IdRefugioNavigationIdRefugio",
                        column: x => x.IdRefugioNavigationIdRefugio,
                        principalTable: "Refugios",
                        principalColumn: "IdRefugio");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Adopciones",
                columns: table => new
                {
                    IdAdopcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPost = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdPostNavigationIdPost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopciones", x => x.IdAdopcion);
                    table.ForeignKey(
                        name: "FK_Adopciones_Post_IdPostNavigationIdPost",
                        column: x => x.IdPostNavigationIdPost,
                        principalTable: "Post",
                        principalColumn: "IdPost");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Apadrinamientos",
                columns: table => new
                {
                    IdApadrinamiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPost = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdPostNavigationIdPost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apadrinamientos", x => x.IdApadrinamiento);
                    table.ForeignKey(
                        name: "FK_Apadrinamientos_Post_IdPostNavigationIdPost",
                        column: x => x.IdPostNavigationIdPost,
                        principalTable: "Post",
                        principalColumn: "IdPost");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    IdComentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Texto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdPost = table.Column<int>(type: "int", nullable: true),
                    IdMascota = table.Column<int>(type: "int", nullable: true),
                    IdProducto = table.Column<int>(type: "int", nullable: true),
                    IdPostNavigationIdPost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.IdComentario);
                    table.ForeignKey(
                        name: "FK_Comentarios_Post_IdPostNavigationIdPost",
                        column: x => x.IdPostNavigationIdPost,
                        principalTable: "Post",
                        principalColumn: "IdPost");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Donaciones",
                columns: table => new
                {
                    IdDonacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdPost = table.Column<int>(type: "int", nullable: true),
                    IdRefugio = table.Column<int>(type: "int", nullable: true),
                    IdPostNavigationIdPost = table.Column<int>(type: "int", nullable: true),
                    IdRefugioNavigationIdRefugio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donaciones", x => x.IdDonacion);
                    table.ForeignKey(
                        name: "FK_Donaciones_Post_IdPostNavigationIdPost",
                        column: x => x.IdPostNavigationIdPost,
                        principalTable: "Post",
                        principalColumn: "IdPost");
                    table.ForeignKey(
                        name: "FK_Donaciones_Refugios_IdRefugioNavigationIdRefugio",
                        column: x => x.IdRefugioNavigationIdRefugio,
                        principalTable: "Refugios",
                        principalColumn: "IdRefugio");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MeGusta",
                columns: table => new
                {
                    IdMeGusta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPost = table.Column<int>(type: "int", nullable: true),
                    IdMascota = table.Column<int>(type: "int", nullable: true),
                    IdPostNavigationIdPost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeGusta", x => x.IdMeGusta);
                    table.ForeignKey(
                        name: "FK_MeGusta_Post_IdPostNavigationIdPost",
                        column: x => x.IdPostNavigationIdPost,
                        principalTable: "Post",
                        principalColumn: "IdPost");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Adopciones_IdPostNavigationIdPost",
                table: "Adopciones",
                column: "IdPostNavigationIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_Apadrinamientos_IdPostNavigationIdPost",
                table: "Apadrinamientos",
                column: "IdPostNavigationIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdPostNavigationIdPost",
                table: "Comentarios",
                column: "IdPostNavigationIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_Donaciones_IdPostNavigationIdPost",
                table: "Donaciones",
                column: "IdPostNavigationIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_Donaciones_IdRefugioNavigationIdRefugio",
                table: "Donaciones",
                column: "IdRefugioNavigationIdRefugio");

            migrationBuilder.CreateIndex(
                name: "IX_MeGusta_IdPostNavigationIdPost",
                table: "MeGusta",
                column: "IdPostNavigationIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_Post_IdRefugioNavigationIdRefugio",
                table: "Post",
                column: "IdRefugioNavigationIdRefugio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adopciones");

            migrationBuilder.DropTable(
                name: "Apadrinamientos");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Donaciones");

            migrationBuilder.DropTable(
                name: "MeGusta");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Refugios");
        }
    }
}
