﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LowOffice.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    caseNum = table.Column<string>(type: "TEXT", nullable: true),
                    Hall = table.Column<string>(type: "TEXT", nullable: true),
                    circleNum = table.Column<string>(type: "TEXT", nullable: true),
                    oppenentName = table.Column<string>(type: "TEXT", nullable: true),
                    attribute = table.Column<string>(type: "TEXT", nullable: true),
                    date = table.Column<string>(type: "TEXT", nullable: true),
                    dateOflast = table.Column<string>(type: "TEXT", nullable: true),
                    describtion = table.Column<string>(type: "TEXT", nullable: true),
                    caseDecision = table.Column<string>(type: "TEXT", nullable: true),
                    Lastone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
