using device_management.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace device_management.Models
{
    public class EquipmentModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int StatusId { get; set; }
    }

    public class EquipmentVM : EquipmentModel
    {
        public int EquipmentId { get; set; }
        public string? Image { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Brand { get; set; }
        public string? Status { get; set; }
    }
}
