

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public HttpClient _httpClient { get; }
        public List<Product> Products { get; set; } = new List<Product>();

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task GetProducts()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/products");
            if (result != null && result.Data != null)
                Products = result.Data;

        }

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/products/{id}");
            return result;
           
        }
    }
}
