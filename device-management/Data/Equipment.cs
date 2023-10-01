using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace device_management.Data
{
    [Table("Equipments")]
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }
        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public EquipmentStatus Status { get; set; }

        public Equipment()
        {
            IsDeleted = false;
            CreatedAt = DateTime.Today;
            UpdatedAt = DateTime.Today;
        }
    }
}
