using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private DataContext _service;
        public ProductsController(DataContext service)
        {
            _service = service;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _service.Products.ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            await _service.Products.AddAsync(product);
            await _service.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("/update")]
        public async Task<ActionResult> Update(Product product)
        {
            var productToUpdate = await _service.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (productToUpdate is null)
            {
                return NotFound();
            }
            else
            {
                productToUpdate.Title = product.Title;
                productToUpdate.Description = product.Description;
                productToUpdate.ImageUrl = product.ImageUrl;
                productToUpdate.Price = product.Price;
            }
            await _service.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _service.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is null) return NotFound();

            _service.Products.Remove(product);

            return NoContent();
        }



    }



}
