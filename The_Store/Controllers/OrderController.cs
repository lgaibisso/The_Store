using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using The_Store.Enums;
using The_Store.Interfaces;
using The_Store.Models;
using The_Store.OperationMessengers.Orders;

namespace The_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusiness _context;

        public OrderController(IOrderBusiness context)
        {
            _context = context;
        }

        //[HttpPost]
        //[Route("PayOrder")]
        //public JsonResult PayOrder(Order id, string creditCardNumber, CreditCard type)
        //{
        //    if (id != null || !string.IsNullOrEmpty(creditCardNumber))
        //    {
        //        try
        //        {
        //            var paymentResult = new Authentication("6dd490faf9cb87a9862245da41170ff2", "024h1IlD");
        //            return new JsonResult(paymentResult);
        //        }
        //        catch (Exception) { return new JsonResult("Error"); }
        //    }
            
        //    return new JsonResult("Error");
        //}

        [HttpGet]
        [Route("GetOrders")]
        public JsonResult GetOrders()
        {
            var operationOut = new GetOrderListOut();
            try
            {
                var operationIn = new GetOrderListIn();
                operationOut = _context.GetOrderList(operationIn);
                if (!operationOut.OperationResultSuccess) return new JsonResult("Error");

                return new JsonResult(operationOut.Orders);
            }
            catch (Exception) { return new JsonResult("Error"); }
        }

        [HttpGet]
        [Route("GetOrderById/{id}")]
        public JsonResult GetOrderById(int id)
        {
            if (id > 0)
            {
                var operationOut = new GetOrderByIdOut();
                try
                {
                    var operationIn = new GetOrderByIdIn { OrderId = id };
                    operationOut = _context.GetOrderById(operationIn);
                    if (!operationOut.OperationResultSuccess) return new JsonResult("Error");

                    return new JsonResult(operationOut.Order);
                }
                catch (Exception) { return new JsonResult("Error"); }
            }
            
            return new JsonResult("Error");
        }

        [HttpPost]
        [Route("CreateOrder")]
        public JsonResult CreateOrder(Order o)
        {
            if (o != null)
            {
                var operationOut = new CreateOrderOut();
                try
                {
                    var operationIn = new CreateOrderIn { Order = o };
                    operationOut = _context.CreateOrder(operationIn);
                    if (!operationOut.OperationResultSuccess) return new JsonResult("Error");

                    return new JsonResult(operationOut.OperationResultSuccess);
                }
                catch (Exception) { return new JsonResult("Error"); }
            }

            return new JsonResult("Error");
        }

        [HttpPost]
        [Route("UpdateOrder")]
        public async Task<JsonResult> UpdateOrder(Payment payment) //Order o, string creditCardNumber, CreditCard type)
        {
            if (payment != null)
            {
                var operationOut = new UpdateOrderOut();
                try
                {
                    var operationIn = new UpdateOrderIn
                    {
                        OrderId = payment.OrderId,
                        CreditCardNumber = payment.CreditCardNumber,
                        CreditCardType = payment.CreditCardType
                    };
                    operationOut = await _context.UpdateOrderAsync(operationIn);
                    if (!operationOut.OperationResultSuccess) return new JsonResult("Error");

                    return new JsonResult(operationOut.NewOrder);
                }
                catch (Exception) { return new JsonResult("Error"); }
            }
            
            return new JsonResult("Error");
        }
    }
}
