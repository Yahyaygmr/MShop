using Dapper;
using MShop.Discount.Context;
using MShop.Discount.Dtos;

namespace MShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DiscountDapperContext _discountDapperContext;

        public DiscountService(DiscountDapperContext discountDapperContext)
        {
            _discountDapperContext = discountDapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "INSERT INTO COUPONS (Code,Rate,IsActive,ValidDate) VALUES (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using var connection = _discountDapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM COUPONS WHERE CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using var connection = _discountDapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "SELECT * FROM COUPONS";
            using var connection = _discountDapperContext.CreateConnection();
            IEnumerable<ResultCouponDto> coupons = await connection.QueryAsync<ResultCouponDto>(query);

            return coupons.ToList();
        }

        public async Task<GetByIdCouponDto> GetCouponAsync(int id)
        {
            string query = "SELECT * FROM COUPONS WHERE CouponId=@couponId";
            var parameter = new DynamicParameters();
            parameter.Add("@couponId", id);
            using var connection = _discountDapperContext.CreateConnection();
            var coupon = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query,parameter);
            return coupon;
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE COUPONS SET Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate WHERE CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);
            using var connection = _discountDapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
