using System;
using System.ComponentModel.DataAnnotations;

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
        public Status Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }

    public enum Status
    {
        CREATED,
        PAYED,
        REJECTED
    }
}
