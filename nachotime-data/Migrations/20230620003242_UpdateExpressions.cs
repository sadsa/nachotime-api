using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using nachotime_data.Models;

#nullable disable

namespace nachotime_data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExpressions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expressions");

            migrationBuilder.AddColumn<List<Expression>>(
                name: "Expressions",
                table: "Cards",
                type: "jsonb",
                defaultValue: "[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expressions",
                table: "Cards");

            migrationBuilder.CreateTable(
                name: "Expressions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CardId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Definition = table.Column<string>(type: "text", nullable: true),
                    IsKnown = table.Column<bool>(type: "boolean", nullable: false),
                    Translation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expressions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expressions_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expressions_CardId",
                table: "Expressions",
                column: "CardId");
        }
    }
}
