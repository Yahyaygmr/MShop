using Microsoft.EntityFrameworkCore;
using MShop.Comment.Entities;
using System.Collections.Generic;

namespace MShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial catalog=MShopCommentDb;User=sa;Password=123456aA*;TrustServerCertificate=true;");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
