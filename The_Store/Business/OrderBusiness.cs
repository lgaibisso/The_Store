using Microsoft.Extensions.Configuration;
using PlacetoPay.Integrations.Library.CSharp.Carrier;
using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;
using PlacetoPay.Integrations.Library.CSharp.Message;
using P2P = PlacetoPay.Integrations.Library.CSharp.PlacetoPay;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using The_Store.Data;
using The_Store.Interfaces;
using The_Store.OperationMessengers.Orders;

namespace The_Store.Business
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private string login;
        private string tranKey;

        public OrderBusiness(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public CreateOrderOut CreateOrder(CreateOrderIn request)
        {
            CreateOrderOut result = new CreateOrderOut();

            try
            {
                _context.Orders.Add(request.Order);
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

        public async Task<UpdateOrderOut> UpdateOrderAsync(UpdateOrderIn request)
        {
            UpdateOrderOut result = new UpdateOrderOut();

            try
            {
                var order = _context.Orders.Find(request.OrderId);

                if (order != null)
                {
                    login = _configuration.GetValue<string>("PaymentCredentials:Login");
                    tranKey = _configuration.GetValue<string>("PaymentCredentials:TranKey");

                    var auth = new Authentication(login, tranKey);
                    // Get Token
                    // Send Payment

                    //var response = await uri.GetAsync<Result>();

                    _context.Orders.Update(order);
                    result.OperationResultSuccess = await _context.SaveChangesAsync() > 0;

                    var getOperationIn = new GetOrderByIdIn() { OrderId = order.Id };
                    result.NewOrder = GetOrderById(getOperationIn).Order;
                }
            }
            catch (Exception e)
            {
                result.Error = e.InnerException;
            }

            return result;
        }

        private bool SendPayment(Models.Order o)
        {
            bool result = false;

            var uri = new Uri("https://test.placetopay.com/redirection/api/session/");
            Gateway gateway = new P2P(login,
                              tranKey,
                              uri,
                              Gateway.TP_REST);

            Amount amount = new Amount(100);
            Payment payment = new Payment("REFERENCE", "DESCRIPTION", amount);
            //RedirectRequest paymentRequest = new RedirectRequest(payment, RETURN_URL, IP_ADDRESS, USER_AGENT, EXPIRATION);

            //RedirectResponse response = gateway.Request(paymentRequest);

            //CollectRequest req = new CollectRequest()

            return result;
        }
    }
}
