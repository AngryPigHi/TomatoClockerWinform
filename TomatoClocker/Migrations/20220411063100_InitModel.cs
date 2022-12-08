using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TomatoClocker.Migrations
{
    public partial class InitModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_DayCount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_DayCount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_FailedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayCountId = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContinuousTime = table.Column<double>(type: "float", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_FailedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_FailedItems_T_DayCount_DayCountId",
                        column: x => x.DayCountId,
                        principalTable: "T_DayCount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_SuccessItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayCountId = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContinuousTime = table.Column<double>(type: "float", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SuccessItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_SuccessItems_T_DayCount_DayCountId",
                        column: x => x.DayCountId,
                        principalTable: "T_DayCount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_FailedItems_DayCountId",
                table: "T_FailedItems",
                column: "DayCountId");

            migrationBuilder.CreateIndex(
                name: "IX_T_SuccessItems_DayCountId",
                table: "T_SuccessItems",
                column: "DayCountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_FailedItems");

            migrationBuilder.DropTable(
                name: "T_SuccessItems");

            migrationBuilder.DropTable(
                name: "T_DayCount");
        }
    }
}
