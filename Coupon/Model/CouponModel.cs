using System.ComponentModel.DataAnnotations;

namespace Service.Shop.Coupons.Model
{
    public class CouponModel
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public double MinDiscount { get; set;}
    }
}
