using device_management.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace device_management.Models
{
    public class RequestModel
    {
        public string? Message { get; set; }
        public int RequestTypeId { get; set; }
        public int RequestStatusId { get; set; }
        public int SenderId { get; set; }
        public int EquipmentId { get; set; }
    }

    public class RequestVM
    {
        public int RequestId { get; set; }
        public string? Message { get; set; }
        public string RequestType { get; set; }
        public string RequestStatus { get; set; }
        public object Sender { get; set; }
        public string EquipmentName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
