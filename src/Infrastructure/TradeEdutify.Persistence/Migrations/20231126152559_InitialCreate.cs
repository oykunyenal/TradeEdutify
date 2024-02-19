using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TradeEdutify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Share",
                columns: table => new
                {
                    ShareID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<double>(type: "double precision", nullable: false),
                    LastUpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Share", x => x.ShareID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    PortfolioID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OperationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    ShareID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.PortfolioID);
                    table.ForeignKey(
                        name: "FK_Portfolio_Share_ShareID",
                        column: x => x.ShareID,
                        principalTable: "Share",
                        principalColumn: "ShareID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolio_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TradeType = table.Column<int>(type: "integer", nullable: false),
                    ShareID = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    OperationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TotalOperationPrice = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transaction_Share_ShareID",
                        column: x => x.ShareID,
                        principalTable: "Share",
                        principalColumn: "ShareID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Share",
                columns: new[] { "ShareID", "LastUpdateDate", "Rate", "Symbol" },
                values: new object[,]
                {
                    { 100L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 25, 59, 820, DateTimeKind.Unspecified).AddTicks(5352), new TimeSpan(0, 3, 0, 0, 0)), 45.43, "AGT" },
                    { 101L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 25, 59, 820, DateTimeKind.Unspecified).AddTicks(5386), new TimeSpan(0, 3, 0, 0, 0)), 30.16, "THY" },
                    { 102L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 25, 59, 820, DateTimeKind.Unspecified).AddTicks(5388), new TimeSpan(0, 3, 0, 0, 0)), 70.319999999999993, "EGS" },
                    { 103L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 25, 59, 820, DateTimeKind.Unspecified).AddTicks(5390), new TimeSpan(0, 3, 0, 0, 0)), 120.76000000000001, "ODR" },
                    { 104L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 25, 59, 820, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 3, 0, 0, 0)), 12.1, "VHY" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Username" },
                values: new object[,]
                {
                    { 100L, "EthanHayes" },
                    { 101L, "OliviaFoster" },
                    { 102L, "AmeliaRodriguez" },
                    { 103L, "SophiaChang" },
                    { 104L, "JacksonBennett" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_ShareID",
                table: "Portfolio",
                column: "ShareID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_UserID",
                table: "Portfolio",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ShareID",
                table: "Transaction",
                column: "ShareID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserID",
                table: "Transaction",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Share");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}