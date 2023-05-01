using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    public partial class ProductDetails
    {
        private Product? product = null;

        private string message = string.Empty;

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            message = "Loading...";
            var result = await ProductService.GetProduct(Id);
            if (result.Success)
            {
                product = result.Data;
            }
            else
            {
                message = result.Message;
            }
           

        }
    }
}
