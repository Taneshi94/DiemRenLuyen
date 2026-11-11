using Microsoft.EntityFrameworkCore;

namespace EventService // Hoặc tên namespace tương ứng của service
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        // Khai báo các DbSet (Bảng dữ liệu) ở đây sau khi tạo Models
    }
}