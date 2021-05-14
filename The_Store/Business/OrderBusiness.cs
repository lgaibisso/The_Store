using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Store.Data;
using The_Store.Interfaces;
using The_Store.OperationMessengers.Orders;

namespace The_Store.Business
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly ApplicationDbContext _context;

        public OrderBusiness(ApplicationDbContext context)
        {
            _context = context;
        }

        public CreateOrderOut CreateOrder(CreateOrderIn request)
        {
            throw new NotImplementedException();
        }

        public GetOrderByIdOut GetOrderById(GetOrderByIdIn request)
        {
            GetOrderByIdOut result = new GetOrderByIdOut();

            try
            {
                result.Order = _context.Orders.Find(request.OrderId);
                result.OperationResultSuccess = true;
            }
            catch (Exception e)
            {
                result.Error = e.InnerException;
            }

            return result;
        }

        public GetOrderListOut GetOrderList(GetOrderListIn request)
        {
            GetOrderListOut result = new GetOrderListOut();

            try
            {
                result.Orders = _context.Orders.ToList();
                result.OperationResultSuccess = true;
            }
            catch (Exception e)
            {
                result.Error = e.InnerException;
            }

            return result;
        }

        public UpdateOrderOut UpdateOrder(UpdateOrderIn request)
        {
            UpdateOrderOut result = new UpdateOrderOut();

            try
            {
                _context.Orders.Update(request.Order);
                result.OperationResultSuccess = _context.SaveChanges() > 0;
                
                var getOperationIn = new GetOrderByIdIn() { OrderId = request.Order.Id };
                result.NewOrder = GetOrderById(getOperationIn).Order;
            }
            catch (Exception e)
            {
                result.Error = e.InnerException;
            }

            return result;
        }
    }
}
