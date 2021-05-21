using System;
using System.ComponentModel.DataAnnotations;
using The_Store.Enums;

namespace The_Store.Models
{
    public class Order
    {
        public int Id { get; set; }

        [StringLength(80)]
        public string Customer_name { get; set; }

        [StringLength(120)]
        public string Customer_email { get; set; }

        [StringLength(40)]
        public string Customer_mobile { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
