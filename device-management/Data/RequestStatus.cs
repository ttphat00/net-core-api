using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace device_management.Data
{
    [Table("RequestStatus")]
    public class RequestStatus
    {
        [Key]
        public int RequestStatusId { get; set; }
        public string RequestStatusName { get; set;}
    }
}
