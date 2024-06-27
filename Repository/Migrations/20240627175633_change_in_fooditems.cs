using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class change_in_fooditems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Items_Restaurants_RestaurantsId",
                table: "Food_Items");

            migrationBuilder.DropIndex(
                name: "IX_Food_Items_RestaurantsId",
                table: "Food_Items");

            migrationBuilder.DropColumn(
                name: "RestaurantsId",
                table: "Food_Items");

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "Food_Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Food_Items_RestaurantId",
                table: "Food_Items",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Items_Restaurants_RestaurantId",
                table: "Food_Items",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Items_Restaurants_RestaurantId",
                table: "Food_Items");

            migrationBuilder.DropIndex(
                name: "IX_Food_Items_RestaurantId",
                table: "Food_Items");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Food_Items");

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantsId",
                table: "Food_Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Food_Items_RestaurantsId",
                table: "Food_Items",
                column: "RestaurantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Items_Restaurants_RestaurantsId",
                table: "Food_Items",
                column: "RestaurantsId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }
    }
}
