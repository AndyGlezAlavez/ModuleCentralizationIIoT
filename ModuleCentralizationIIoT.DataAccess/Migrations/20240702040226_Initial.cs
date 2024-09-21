using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleCentralizationIIoT.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModuleIIoTs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AddresIp = table.Column<string>(type: "TEXT", nullable: false),
                    AccessPort = table.Column<string>(type: "TEXT", nullable: false),
                    IsConnected = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleIIoTs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Area = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    CreationMessage = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    ModuleIIoTId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_ModuleIIoTs_ModuleIIoTId",
                        column: x => x.ModuleIIoTId,
                        principalTable: "ModuleIIoTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleIIoTUnity",
                columns: table => new
                {
                    ModuleIIoTsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UnitiesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleIIoTUnity", x => new { x.ModuleIIoTsId, x.UnitiesId });
                    table.ForeignKey(
                        name: "FK_ModuleIIoTUnity_ModuleIIoTs_ModuleIIoTsId",
                        column: x => x.ModuleIIoTsId,
                        principalTable: "ModuleIIoTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleIIoTUnity_Unities_UnitiesId",
                        column: x => x.UnitiesId,
                        principalTable: "Unities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ModuleIIoTId",
                table: "Messages",
                column: "ModuleIIoTId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleIIoTUnity_UnitiesId",
                table: "ModuleIIoTUnity",
                column: "UnitiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ModuleIIoTUnity");

            migrationBuilder.DropTable(
                name: "ModuleIIoTs");

            migrationBuilder.DropTable(
                name: "Unities");
        }
    }
}
