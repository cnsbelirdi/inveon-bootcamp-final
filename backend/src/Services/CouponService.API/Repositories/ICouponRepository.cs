using CouponService.API.Dtos;

namespace CouponService.API.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}

