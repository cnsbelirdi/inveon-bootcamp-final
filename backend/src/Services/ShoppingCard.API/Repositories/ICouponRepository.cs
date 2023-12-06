using ShoppingCard.API.Dtos;

namespace ShoppingCard.API.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
