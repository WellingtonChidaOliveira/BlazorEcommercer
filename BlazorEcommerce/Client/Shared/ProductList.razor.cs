namespace BlazorEcommerce.Client.Shared
{
    public partial class ProductList
    {

        protected override void OnInitialized()
        {
           ProductService.ProductsChanged += StateHasChanged;
        }

        public void Dispose()
        {
            ProductService.ProductsChanged -= StateHasChanged;
        }
    }
}
