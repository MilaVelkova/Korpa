using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Delivery_Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Food_Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RestaurantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_Items_Restaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodInOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Food_ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Delivery_OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodInOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodInOrders_Delivery_Orders_Delivery_OrdersId",
                        column: x => x.Delivery_OrdersId,
                        principalTable: "Delivery_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodInOrders_Food_Items_Food_ItemsId",
                        column: x => x.Food_ItemsId,
                        principalTable: "Food_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodInShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Food_ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodInShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodInShoppingCarts_Food_Items_Food_ItemsId",
                        column: x => x.Food_ItemsId,
                        principalTable: "Food_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodInShoppingCarts_Restaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodInShoppingCarts_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Orders_CustomerId",
                table: "Delivery_Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Items_RestaurantsId",
                table: "Food_Items",
                column: "RestaurantsId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInOrders_Delivery_OrdersId",
                table: "FoodInOrders",
                column: "Delivery_OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInOrders_Food_ItemsId",
                table: "FoodInOrders",
                column: "Food_ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInShoppingCarts_Food_ItemsId",
                table: "FoodInShoppingCarts",
                column: "Food_ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInShoppingCarts_RestaurantsId",
                table: "FoodInShoppingCarts",
                column: "RestaurantsId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInShoppingCarts_ShoppingCartId",
                table: "FoodInShoppingCarts",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CustomerId",
                table: "ShoppingCarts",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodInOrders");

            migrationBuilder.DropTable(
                name: "FoodInShoppingCarts");

            migrationBuilder.DropTable(
                name: "Delivery_Orders");

            migrationBuilder.DropTable(
                name: "Food_Items");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
