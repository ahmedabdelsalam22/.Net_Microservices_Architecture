﻿using Mango.FrontEnd.Models.DTOS;
using Mango.Web.Models.DTOS;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> AssignRole(RegisterRequestDTO registerRequestDTO)
        {
            ResponseDTO? responseDTO = await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Url = SD.AuthAPIBase + "/api/auth/assignRole",
                Data = registerRequestDTO
            });
            return responseDTO;
        }

        public async Task<ResponseDTO?> Login(LoginRequestDTO loginRequestDTO)
        {
            ResponseDTO? responseDTO = await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Url = SD.AuthAPIBase + "/api/auth/login",
                Data = loginRequestDTO
            });
            return responseDTO;
        }

        public async Task<ResponseDTO?> Register(RegisterRequestDTO registerRequestDTO)
        {
            ResponseDTO? responseDTO = await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Url = SD.AuthAPIBase + "/api/auth/register",
                Data = registerRequestDTO
            });
            return responseDTO;
        }
    }
}