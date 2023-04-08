using Microsoft.AspNetCore.Mvc;

using TechnicalTestApi.Domain;
using TechnicalTestApi.Application.Services;
using TechnicalTestApi.Infrastructure.Contexts;
using TechnicalTestApi.Infrastructure.Repositories;
using System.Net.WebSockets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnicalTestApi.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrderController : ControllerBase
    {
        SaleOrderService createService()
        {
            SaleOrderContext saleOrderContextDb = new SaleOrderContext();
            SaleOrderRepository saleOrderRepository = new SaleOrderRepository(saleOrderContextDb);
            ProductRepository productRepository = new ProductRepository(saleOrderContextDb);
            SaleOrderDetailRepository saleOrderDetailRepository = new SaleOrderDetailRepository(saleOrderContextDb);    
            SaleOrderService saleOrderService = new SaleOrderService(
                saleOrderRepository, productRepository, saleOrderDetailRepository);
            return saleOrderService;
        }

        // GET: api/<SaleOrderController>
        [HttpGet]
        public ActionResult<List<SaleOrder>> Get()
        {
            var service = createService();
            return Ok(service.GetAll());
        }

        // GET api/<SaleOrderController>/5
        [HttpGet("{id}")]
        public ActionResult<SaleOrder> Get(Guid entityId)
        {
            var service = createService();
            return Ok(service.GetById(entityId)); 
        }

        // POST api/<SaleOrderController>
        [HttpPost]
        public ActionResult Post([FromBody] SaleOrder SaleOrder)
        {
            var service = createService();  
            service.Add(SaleOrder);
            return Ok("Venta Registrada!.");
        }

        // DELETE api/<SaleOrderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid entityId)
        {
            var service = createService();
            service.Annull(entityId);
            return Ok("Venta anulada");
        }
    }
}
