using Microsoft.EntityFrameworkCore;

namespace AuthServer
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        // Sau này khi có các bảng dữ liệu (Models) thì khai báo DbSet ở đây
    }
}