using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    public class CameraContext : DbContext
    {
        public DbSet<Camera> Cameras { get; set; }
        
        public CameraContext(DbContextOptions<CameraContext> options)
            : base(options)
        { }
        
        
    }
}