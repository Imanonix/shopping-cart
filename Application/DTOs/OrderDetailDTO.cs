using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderDetailDTO
    {
        public Guid? DetailId { get; set; }
        
        public Guid? OrderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }

        [Required] 
        public string Title { get; set; } = string.Empty;
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        
    }
}
