using The_Store.Messengers.Base;
using The_Store.Models;

namespace The_Store.OperationMessengers.Orders
{
    public class CreateOrderIn : BaseOperationIn
    {
        public Order Order { get; set; }
    }
}
