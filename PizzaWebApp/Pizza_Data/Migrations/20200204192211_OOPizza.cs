using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza_Data.Migrations
{
    public partial class OOPizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_User",
                columns: table => new
                {
                    username = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Pass = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___User__F3DBC5733C3A50F6", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    storeName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    venue = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Store__0E3E451C199CC4C7", x => x.storeName);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    pizzaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crust = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    size = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    username = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    pizzaType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pizzas__4D4C90EF095EE0CB", x => x.pizzaId);
                    table.ForeignKey(
                        name: "FK__Pizzas__username__49C3F6B7",
                        column: x => x.username,
                        principalTable: "_User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalCharges = table.Column<decimal>(type: "money", nullable: false),
                    placedAt = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    username = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    storeName = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__0809335D02FEB31D", x => x.orderId);
                    table.ForeignKey(
                        name: "FK__Orders__storeNam__6A30C649",
                        column: x => x.storeName,
                        principalTable: "Store",
                        principalColumn: "storeName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Orders__username__6B24EA82",
                        column: x => x.username,
                        principalTable: "_User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompletedOrders",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Complete__0809335D1A05C904", x => x.orderId);
                    table.ForeignKey(
                        name: "FK__Completed__order__6E01572D",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_storeName",
                table: "Orders",
                column: "storeName");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_username",
                table: "Orders",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_username",
                table: "Pizzas",
                column: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedOrders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "_User");
        }
    }
}
