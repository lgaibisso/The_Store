using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using The_Store.Controllers.Common;
using The_Store.Interfaces;
using The_Store.Models;
using The_Store.OperationMessengers.Orders;

namespace The_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        private readonly IOrderBusiness _context;

        public OrderController(IOrderBusiness context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetOrders()
        {
            var operationOut = new GetOrderListOut();
            try
            {
                var operationIn = new GetOrderListIn();
                operationOut = _context.GetOrderList(operationIn);
                if (!operationOut.OperationResultSuccess) throw CreateApiError(operationOut);

                return new JsonResult(operationOut);
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public JsonResult GetOrder(Order o)
        {
            var operationOut = new GetOrderByIdOut();
            try
            {
                var operationIn = new GetOrderByIdIn { OrderId = o.Id };
                operationOut = _context.GetOrderById(operationIn);
                if (!operationOut.OperationResultSuccess) throw CreateApiError(operationOut);

                return new JsonResult(operationOut);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public JsonResult InsertOrder(Order o)
        {
            var operationOut = new CreateOrderOut();
            try
            {
                var operationIn = new CreateOrderIn { Order = o };
                operationOut = _context.CreateOrder(operationIn);
                if (!operationOut.OperationResultSuccess) throw CreateApiError(operationOut);

                return new JsonResult(operationOut.NewOrder);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPut]
        public JsonResult UpdateOrder(Order o)
        {
            var operationOut = new UpdateOrderOut();
            try
            {
                var operationIn = new UpdateOrderIn { Order = o };
                operationOut = _context.UpdateOrder(operationIn);
                if (!operationOut.OperationResultSuccess) throw CreateApiError(operationOut);

                return new JsonResult(operationOut.NewOrder);
            }
            catch (Exception e) { throw e; }
        }
    }
}
