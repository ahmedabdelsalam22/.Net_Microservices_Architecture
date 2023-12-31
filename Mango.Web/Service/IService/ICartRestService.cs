﻿using Mango.Web.Models.Dtos;
using Mango.Web.RestService.IRestService;
using RestSharp;

namespace Mango.Web.Service.IService
{
    public interface ICartRestService : IRestService<CartDto>
    {
        
    }
}
