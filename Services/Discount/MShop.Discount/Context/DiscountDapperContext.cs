using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MShop.Discount.Entities;
using System.Data;

namespace MShop.Discount.Context
{
    public class DiscountDapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DiscountDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=DESKTOP-4QIIH5S; initial catalog=MShopDiscountDb;integrated security=true;TrustServerCertificate=true;");
        //}
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
