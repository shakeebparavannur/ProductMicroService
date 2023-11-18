using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroService.Model;
using ProductMicroService.Repository;
using System.Transactions;

namespace ProductMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        public ProductController(IProductService productService)
        {
            service= productService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = service.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}",Name ="Get")]
        public IActionResult Get(int id)
        {
            var product = service.GetProductById(id);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            service.InsertProduct(product);
            return Ok("Successfully Added");
        }
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            service.UpdateProduct(product);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
           service.DeleteProduct(id);
            return Ok();
        }
    }
}
