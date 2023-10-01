using Microsoft.EntityFrameworkCore;

namespace device_management.Data
{
    public class DeviceManagementContext : DbContext
    {
        public DeviceManagementContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<EquipmentStatus> EquipmentStatuses { get; set; }
        public DbSet<Equipment> Equipments { get; set; } 
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<BorrowingEquipment> BorrowingEquipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BorrowingEquipment>(e =>
            {
                e.HasKey(be => new { be.UserId, be.EquipmentId });
            });
        }
    }
}
