namespace BlazorEcommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public DataContext _service;
        public CategoryService(DataContext service)
        {
            _service = service;
        }

       

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories = await _service.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories
            };
        }
    }
}
