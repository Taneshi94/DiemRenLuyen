using Microsoft.EntityFrameworkCore;

namespace ScoreService // Hoặc tên namespace tương ứng của service
{
    public class ScoreDbContext : DbContext
    {
        public ScoreDbContext(DbContextOptions<ScoreDbContext> options) : base(options)
        {
        }

        // Khai báo các DbSet (Bảng dữ liệu) ở đây sau khi tạo Models
    }
}