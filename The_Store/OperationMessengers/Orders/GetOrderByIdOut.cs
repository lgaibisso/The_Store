using The_Store.Models;
using The_Store.OperationMessengers.Base;

namespace The_Store.OperationMessengers.Orders
{
    public class GetOrderByIdOut : BaseOperationOut
    {
        public Order Order { get; set; }

    }
}
