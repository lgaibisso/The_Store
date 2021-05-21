﻿using The_Store.Enums;
using The_Store.Messengers.Base;
using The_Store.Models;

namespace The_Store.OperationMessengers.Orders
{
    public class UpdateOrderIn : BaseOperationIn
    {
        public int OrderId { get; set; }

        public CreditCard CreditCardType { get; set; }

        public string CreditCardNumber { get; set; }
    }
}
