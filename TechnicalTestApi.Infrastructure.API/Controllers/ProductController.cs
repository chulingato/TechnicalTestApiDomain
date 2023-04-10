 using Microsoft.AspNetCore.Mvc;

using TechnicalTestApi.Domain;
using TechnicalTestApi.Application.Services;
using TechnicalTestApi.Infrastructure.Contexts;
using TechnicalTestApi.Infrastructure.Repositories;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnicalTestApi.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService createService()
        {
            SaleOrderContext saleOrderContextDb = new SaleOrderContext();
            ProductRepository productRepository = new ProductRepository(saleOrderContextDb);
            ProductService productService = new ProductService(productRepository);
            return productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var service = createService();
            return Ok(service.GetAll());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(Guid id)
        {
            var service = createService();
            return Ok(service.GetById(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            try {
                var service = createService();
                service.Add(product);

                return Ok("Producto Agregado!");
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Product product)
        {
            try { 
                var service = createService();
                product.productId = id;
                service.Edit(product);

                return Ok("Producto Editado.");
             }catch (Exception e)
            {
                return BadRequest(e.Message);
             }
}

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var service = createService();
            service.Delete(id);
            return Ok("Producto eliminado");
        }
    }
}
