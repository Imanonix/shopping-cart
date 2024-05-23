using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class YearlyData<T>
    {
        public int Year { get; set; }
        public string? Month { get; set; }
        public T? Amount { get; set; }
    }

    public class KeyValue<T>
    {
        public string Key { get; set; } = string.Empty;
        public T? Value { get; set; }
    }
    
}
