using System.Collections.Generic;
using The_Store.Models;
using The_Store.OperationMessengers.Base;

namespace The_Store.OperationMessengers.Orders
{
    public class GetOrderListOut : BaseOperationOut
    {
        public List<Order> Orders { get; set; }

    }
}
