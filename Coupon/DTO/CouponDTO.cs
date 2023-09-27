using System.ComponentModel.DataAnnotations;

namespace Service.Shop.Coupons.DTO
{
    public class CouponDTO
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public required string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public double MinDiscount { get; set;}
    }
}
