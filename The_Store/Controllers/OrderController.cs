using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Store.Data;
using The_Store.Models;

namespace The_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public OrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetOrders()
        {
            return new JsonResult("Test Funciona");
        }

        [HttpGet]
        public JsonResult GetOrder(Order o)
        {
            return new JsonResult("0");
        }

        [HttpPost]
        public JsonResult InsertOrder(Order o)
        {

            return new JsonResult("0");
        }

        [HttpPut]
        public JsonResult UpdateOrder(Order o)
        {
            return new JsonResult("0");
        }

        [HttpDelete]
        public JsonResult DeleteOrder(Order o)
        {
            return new JsonResult("0");
        }
    }
}
