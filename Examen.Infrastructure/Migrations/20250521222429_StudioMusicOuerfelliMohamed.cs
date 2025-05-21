using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StudioMusicOuerfelliMohamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collaborateurs",
                columns: table => new
                {
                    CollaborateurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCollaborateur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleCollaborateur = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborateurs", x => x.CollaborateurId);
                });

            migrationBuilder.CreateTable(
                name: "Musiciens",
                columns: table => new
                {
                    MusicienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMusicien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTelephone = table.Column<int>(type: "int", nullable: false),
                    DateCarriere = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musiciens", x => x.MusicienId);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    StudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomStudio = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PrixHeure = table.Column<float>(type: "real", nullable: false),
                    Superficie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.StudioId);
                });

            migrationBuilder.CreateTable(
                name: "Collaborations",
                columns: table => new
                {
                    CollaborateursCollaborateurId = table.Column<int>(type: "int", nullable: false),
                    MusiciensMusicienId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborations", x => new { x.CollaborateursCollaborateurId, x.MusiciensMusicienId });
                    table.ForeignKey(
                        name: "FK_Collaborations_Collaborateurs_CollaborateursCollaborateurId",
                        column: x => x.CollaborateursCollaborateurId,
                        principalTable: "Collaborateurs",
                        principalColumn: "CollaborateurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaborations_Musiciens_MusiciensMusicienId",
                        column: x => x.MusiciensMusicienId,
                        principalTable: "Musiciens",
                        principalColumn: "MusicienId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipements",
                columns: table => new
                {
                    EquipementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoEquipement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeEquipement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtatEquipement = table.Column<int>(type: "int", nullable: false),
                    StudioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipements", x => x.EquipementId);
                    table.ForeignKey(
                        name: "FK_Equipements_Studios_StudioFk",
                        column: x => x.StudioFk,
                        principalTable: "Studios",
                        principalColumn: "StudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MuscienFk = table.Column<int>(type: "int", nullable: false),
                    StudioFk = table.Column<int>(type: "int", nullable: false),
                    Confirme = table.Column<bool>(type: "bit", nullable: false),
                    NbrHeure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.MuscienFk, x.StudioFk, x.DateReservation });
                    table.ForeignKey(
                        name: "FK_Reservations_Musiciens_MuscienFk",
                        column: x => x.MuscienFk,
                        principalTable: "Musiciens",
                        principalColumn: "MusicienId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Studios_StudioFk",
                        column: x => x.StudioFk,
                        principalTable: "Studios",
                        principalColumn: "StudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborations_MusiciensMusicienId",
                table: "Collaborations",
                column: "MusiciensMusicienId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_StudioFk",
                table: "Equipements",
                column: "StudioFk");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StudioFk",
                table: "Reservations",
                column: "StudioFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborations");

            migrationBuilder.DropTable(
                name: "Equipements");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Collaborateurs");

            migrationBuilder.DropTable(
                name: "Musiciens");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
