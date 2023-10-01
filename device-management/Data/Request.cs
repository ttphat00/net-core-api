using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace device_management.Data
{
    [Table("Requests")]
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public string? Message { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public int RequestTypeId { get; set; }
        [ForeignKey(nameof(RequestTypeId))]
        public RequestType RequestType { get; set; }
        public int RequestStatusId { get; set; }
        [ForeignKey(nameof(RequestStatusId))]
        public RequestStatus RequestStatus { get; set; }
        public int CreatedBy { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        public User User { get; set; }
        public int EquipmentId { get; set; }
        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; }

        public Request()
        {
            IsDeleted = false;
            CreatedAt = DateTime.Today;
            UpdatedAt = DateTime.Today;
        }
    }
}
