﻿using BlazorEcommerce.Shared;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Shared
{
    public partial class ProductList
    {
        private List<Product> Products = new List<Product>();

        protected override async Task OnInitializedAsync()
        {
            var result = await Http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Products");
            if(result != null && result.Data != null)
            {
                Products = result.Data;
            }
        }
    }
}
