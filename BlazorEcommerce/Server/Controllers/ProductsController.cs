using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;

        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> Get()
        {
            var products = await _service.Get();
            return Ok(products);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> Get(int id)
        {
            var product = await _service.Get(id);
            return Ok(product);
        }
        [HttpGet]
        [Route("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductByCategory(string categoryUrl)
        {
            var products = await _service.GetProductByCategory(categoryUrl);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            var response = await _service.Add(product);
            return Ok(response);
        }

        [HttpPost("/update")]
        public async Task<ActionResult> Update(Product product)
        {
            var response = await _service.Update(product);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
           var response = await _service.Delete(id);

            return Ok(response);
        }



    }



}
