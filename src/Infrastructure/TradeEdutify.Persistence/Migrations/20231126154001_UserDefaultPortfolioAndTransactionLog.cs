using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TradeEdutify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserDefaultPortfolioAndTransactionLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Portfolio",
                columns: new[] { "PortfolioID", "OperationDate", "ShareID", "UserID" },
                values: new object[,]
                {
                    { 100L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9812), new TimeSpan(0, 3, 0, 0, 0)), 100L, 100L },
                    { 101L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9814), new TimeSpan(0, 3, 0, 0, 0)), 102L, 101L },
                    { 102L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9816), new TimeSpan(0, 3, 0, 0, 0)), 103L, 101L },
                    { 103L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9818), new TimeSpan(0, 3, 0, 0, 0)), 104L, 102L },
                    { 104L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9820), new TimeSpan(0, 3, 0, 0, 0)), 103L, 102L }
                });

            migrationBuilder.UpdateData(
                table: "Share",
                keyColumn: "ShareID",
                keyValue: 100L,
                column: "LastUpdateDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9746), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Share",
                keyColumn: "ShareID",
                keyValue: 101L,
                column: "LastUpdateDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9786), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Share",
                keyColumn: "ShareID",
                keyValue: 102L,
                column: "LastUpdateDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9788), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Share",
                keyColumn: "ShareID",
                keyValue: 103L,
                column: "LastUpdateDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9790), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Share",
                keyColumn: "ShareID",
                keyValue: 104L,
                column: "LastUpdateDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9793), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TransactionID", "OperationDate", "Quantity", "ShareID", "TotalOperationPrice", "TradeType", "UnitPrice", "UserID" },
                values: new object[,]
                {
                    { 100L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9835), new TimeSpan(0, 3, 0, 0, 0)), 3, 100L, 136.28999999999999, 0, 45.439999999999998, 100L },
                    { 101L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9838), new TimeSpan(0, 3, 0, 0, 0)), 20, 102L, 603.20000000000005, 0, 30.16, 101L },
                    { 103L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9841), new TimeSpan(0, 3, 0, 0, 0)), 10, 103L, 1207.6000000000001, 0, 120.76000000000001, 101L },
                    { 104L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9843), new TimeSpan(0, 3, 0, 0, 0)), 5, 103L, 628.80000000000007, 1, 125.76000000000001, 101L },
                    { 105L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9845), new TimeSpan(0, 3, 0, 0, 0)), 5, 104L, 60.5, 0, 12.1, 102L },
                    { 106L, new DateTimeOffset(new DateTime(2023, 11, 26, 18, 40, 1, 265, DateTimeKind.Unspecified).AddTicks(9847), new TimeSpan(0, 3, 0, 0, 0)), 20, 103L, 2415.2000000000003, 0, 120.76000000000001, 102L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Portfolio",
                keyColumn: "PortfolioID",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Portfolio",
                keyColumn: "PortfolioID",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Portfolio",
                keyColumn: "PortfolioID",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Portfolio",
                keyColumn: "PortfolioID",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Portfolio",
                keyColumn: "PortfolioID",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 106L);

            migrationBuilder.UpdateData(
                table: "Share",
                keyColumn: "ShareID",
                keyValue: 100L,
                column: "LastUpdateDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 18, 25, 59, 820, DateTimeKind.Unspecified).AddTicks(5352), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Share",
                keyColumn: "ShareID",
                keyValue: 101L,
                column: "LastUpdateDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 18, 25, 59, 820, DateTimeKind.Unspecified).AddTicks(5386), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Share",
                keyColumn: "ShareID",
                keyValue: 102L,
                column: "LastUpdateDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 18, 25, 59, 820, DateTimeKind.Unspecified).AddTicks(5388), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Share",
                keyColumn: "ShareID",
                keyValue: 103L,
                column: "LastUpdateDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 18, 25, 59, 820, DateTimeKind.Unspecified).AddTicks(5390), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Share",
                keyColumn: "ShareID",
                keyValue: 104L,
                column: "LastUpdateDate",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 18, 25, 59, 820, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}