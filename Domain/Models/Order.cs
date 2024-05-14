using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public decimal OrderSum { get; set; }
        [Required]
        public bool IsFinaly { get; set; }
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public User User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
