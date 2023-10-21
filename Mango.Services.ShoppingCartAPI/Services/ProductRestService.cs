﻿using Mango.Services.ShoppingCartAPI.Models.Dtos;
using Mango.Services.ShoppingCartAPI.Services.IServices;
using Mango.Services.ShoppingCartAPI.Utility;
using RestSharp;
using System;

namespace Mango.Services.ShoppingCartAPI.Services
{
    public class ProductRestService : RestService<ProductDto>,IProductRestService
    {
    }
}
