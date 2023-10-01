using device_management.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace device_management.Models
{
    public class BrandModel
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string DeviceType { get; set; }
        public bool IsDeleted { get; set; }
    }
}
