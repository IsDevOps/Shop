using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Service.Shop.Coupons.Model;

namespace Service.Shop.Coupons.Database
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options): base(options) {
            
        }
        public DbSet<CouponModel> Coupons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CouponModel>().HasData(new CouponModel
            {
                CouponId = 1,
                CouponCode = "EYR463#",
                DiscountAmount = 30,
                MinDiscount = 50
            });
            modelBuilder.Entity<CouponModel>().HasData(new CouponModel
            {
                CouponId = 2,
                CouponCode = "RT63#",
                DiscountAmount = 30,
                MinDiscount = 90
            });
            modelBuilder.Entity<CouponModel>().HasData(new CouponModel
            {
                CouponId = 3,
                CouponCode = "E763#",
                DiscountAmount = 30,
                MinDiscount = 20
            });
            modelBuilder.Entity<CouponModel>().HasData(new CouponModel
            {
                CouponId = 4,
                CouponCode = "E763748",
                DiscountAmount = 30,
                MinDiscount = 800
            });
            modelBuilder.Entity<CouponModel>().HasData(new CouponModel
            {
                CouponId = 5,
                CouponCode = "DU7448",
                DiscountAmount = 30,
                MinDiscount = 500
            });
        }
    }
}
