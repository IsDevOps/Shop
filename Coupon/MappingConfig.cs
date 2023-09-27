using AutoMapper;
using Service.Shop.Coupons.DTO;
using Service.Shop.Coupons.Model;

namespace Service.Shop.Coupons
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() {
            var mapping = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, CouponModel>();
                config.CreateMap < CouponModel, CouponDTO>();

            });
            return mapping;
        }
    }
}
