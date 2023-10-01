using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace device_management.Data
{
    [Table("EquipmentStatus")]
    public class EquipmentStatus
    {
        [Key]
        public int EquipmentStatusId { get; set; }
        public string Name { get; set; }
    }
}
