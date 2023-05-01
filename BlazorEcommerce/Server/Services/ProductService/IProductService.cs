namespace BlazorEcommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> Get();
        Task<ServiceResponse<Product>> Get(int id);
        Task<ServiceResponse<List<Product>>> Add(Product product);
        Task<ServiceResponse<Product>> Update(Product product);
        Task<ServiceResponse<List<Product>>> Delete(int id);

    }
}
