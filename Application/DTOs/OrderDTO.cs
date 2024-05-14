using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderDTO
    {
        public Guid? OrderId { get; set; }
        public string Email { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public decimal OrderSum { get; set; }
        public List<OrderDetailDTO> orderDetailDTOs { get; set; }
    }
}
