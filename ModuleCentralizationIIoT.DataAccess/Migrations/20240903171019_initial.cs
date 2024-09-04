using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleCentralizationIIoT.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModuleIIoT",
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
                    table.PrimaryKey("PK_ModuleIIoT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Area = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
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
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_ModuleIIoT_ModuleIIoTId",
                        column: x => x.ModuleIIoTId,
                        principalTable: "ModuleIIoT",
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
                        name: "FK_ModuleIIoTUnity_ModuleIIoT_ModuleIIoTsId",
                        column: x => x.ModuleIIoTsId,
                        principalTable: "ModuleIIoT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleIIoTUnity_Unity_UnitiesId",
                        column: x => x.UnitiesId,
                        principalTable: "Unity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_ModuleIIoTId",
                table: "Message",
                column: "ModuleIIoTId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleIIoTUnity_UnitiesId",
                table: "ModuleIIoTUnity",
                column: "UnitiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "ModuleIIoTUnity");

            migrationBuilder.DropTable(
                name: "ModuleIIoT");

            migrationBuilder.DropTable(
                name: "Unity");
        }
    }
}
