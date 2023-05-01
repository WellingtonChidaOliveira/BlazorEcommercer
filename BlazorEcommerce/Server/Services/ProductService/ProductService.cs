namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private DataContext _service;
        public ProductService(DataContext service)
        {
            _service = service;
        }
        public async Task<ServiceResponse<List<Product>>> Add(Product product)
        {
            await _service.AddAsync(product);
            await _service.SaveChangesAsync();
            return new ServiceResponse<List<Product>>()
            {
                Data = await _service.Products.ToListAsync(),
                Message = "Product added successfully",
                Success = true
            };
        }

        public async Task<ServiceResponse<List<Product>>> Delete(int id)
        {
            var product = await Get(id);
            if (product is null) return new ServiceResponse<List<Product>>()
            {
                Data = null,
                Message = "Product not found",
                Success = false
            };
            if (product.Data != null)
                _service.Products.Remove(product.Data);
            return new ServiceResponse<List<Product>>()
            {
                Data = await _service.Products.ToListAsync(),
                Message = "Product deleted successfully",
                Success = true
            };

        }

        public async Task<ServiceResponse<List<Product>>> Get()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _service.Products.ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> Get(int id)
        {
            var response = new ServiceResponse<Product>();

            var product = await _service.Products.FindAsync(id);
            if(product is null)
            {
                response.Message = "Product not found";
                response.Success = false;
            }
            else
            {
                response.Data = product;
                response.Message = "Product found";
                response.Success = true;
            }
            return response;
        }

        public async Task<ServiceResponse<Product>> Update(Product product)
        {
            var productToUpdate = await Get(product.Id);
            if (productToUpdate is null)
            {
                return new ServiceResponse<Product>()
                {
                    Data = null,
                    Message = "Product not found",
                    Success = false
                };
            }
            else
            {
                productToUpdate.Data.Title = product.Title;
                productToUpdate.Data.Description = product.Description;
                productToUpdate.Data.ImageUrl = product.ImageUrl;
                productToUpdate.Data.Price = product.Price;
            }
            await _service.SaveChangesAsync();
            return new ServiceResponse<Product>()
            {
                Data = productToUpdate.Data,
                Message = "Product updated successfully",
                Success = true
            };
        }
    }
}
