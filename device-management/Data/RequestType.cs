using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace device_management.Data
{
    [Table("RequestTypes")]
    public class RequestType
    {
        [Key]
        public int RequestTypeId { get; set; }
        public string RequestName { get; set; }
    }
}
