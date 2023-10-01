using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace device_management.Data
{
    [Table("DeviceTypes")]
    public class DeviceType
    {
        [Key]
        public int DeviceTypeId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
