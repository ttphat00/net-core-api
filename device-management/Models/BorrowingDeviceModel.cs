using device_management.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace device_management.Models
{
    public class BorrowingDeviceModel
    {
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
    }

    public class BorrowingDeviceVM : BorrowingDeviceModel
    {
        public object User { get; set; }
        public string EquipmentName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
