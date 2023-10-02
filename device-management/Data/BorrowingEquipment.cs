using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace device_management.Data
{
    [Table("BorrowingEquipments")]
    public class BorrowingEquipment
    {
        //[Key]
        //public int Id { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int EquipmentId { get; set; }
        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; }

        public BorrowingEquipment()
        {
            IsDeleted = false;
            CreatedAt = DateTime.Today;
            UpdatedAt = DateTime.Today;
        }
    }
}
