using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid DetailId { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int Count { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
        
        public Product Product { get; set; }
    }
}
