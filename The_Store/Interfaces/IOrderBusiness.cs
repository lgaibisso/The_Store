using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Store.OperationMessengers.Orders;

namespace The_Store.Interfaces
{
    public interface IOrderBusiness
    {
        /// <summary>
        /// Gets an order by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetOrderByIdOut GetOrderById(GetOrderByIdIn request);

        /// <summary>
        /// Gets the orders list
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetOrderListOut GetOrderList(GetOrderListIn request);

        /// <summary>
        /// Creates an Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateOrderOut CreateOrder(CreateOrderIn request);

        /// <summary>
        /// Updates an Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateOrderOut> UpdateOrderAsync(UpdateOrderIn request);
    }
}
