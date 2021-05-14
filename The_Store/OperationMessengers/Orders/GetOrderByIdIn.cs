using The_Store.Messengers.Base;

namespace The_Store.OperationMessengers.Orders
{
    public class GetOrderByIdIn : BaseOperationIn
    {
        public int OrderId { get; set; }
    }
}