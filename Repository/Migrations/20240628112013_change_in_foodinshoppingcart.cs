using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class change_in_foodinshoppingcart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodInShoppingCarts_Food_Items_Food_ItemsId",
                table: "FoodInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodInShoppingCarts_Restaurants_RestaurantsId",
                table: "FoodInShoppingCarts");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantsId",
                table: "FoodInShoppingCarts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Food_ItemsId",
                table: "FoodInShoppingCarts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodInShoppingCarts_Food_Items_Food_ItemsId",
                table: "FoodInShoppingCarts",
                column: "Food_ItemsId",
                principalTable: "Food_Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodInShoppingCarts_Restaurants_RestaurantsId",
                table: "FoodInShoppingCarts",
                column: "RestaurantsId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodInShoppingCarts_Food_Items_Food_ItemsId",
                table: "FoodInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodInShoppingCarts_Restaurants_RestaurantsId",
                table: "FoodInShoppingCarts");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantsId",
                table: "FoodInShoppingCarts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Food_ItemsId",
                table: "FoodInShoppingCarts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodInShoppingCarts_Food_Items_Food_ItemsId",
                table: "FoodInShoppingCarts",
                column: "Food_ItemsId",
                principalTable: "Food_Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodInShoppingCarts_Restaurants_RestaurantsId",
                table: "FoodInShoppingCarts",
                column: "RestaurantsId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
