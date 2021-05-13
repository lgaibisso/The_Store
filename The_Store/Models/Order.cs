using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Store.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer_name { get; set; }
        public string Customer_email { get; set; }
        public string Customer_mobile { get; set; }
        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
