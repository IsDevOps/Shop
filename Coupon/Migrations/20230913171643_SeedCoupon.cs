using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Service.Shop.Coupons.Migrations
{
    /// <inheritdoc />
    public partial class SeedCoupon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CouponCode",
                table: "Coupons",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CouponCode", "DiscountAmount", "MinDiscount" },
                values: new object[,]
                {
                    { 1, "EYR463#", 30.0, 50.0 },
                    { 2, "RT63#", 30.0, 90.0 },
                    { 3, "E763#", 30.0, 20.0 },
                    { 4, "E763748", 30.0, 800.0 },
                    { 5, "DU7448", 30.0, 500.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 5);

            migrationBuilder.AlterColumn<double>(
                name: "CouponCode",
                table: "Coupons",
                type: "double",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");
        }
    }
}
