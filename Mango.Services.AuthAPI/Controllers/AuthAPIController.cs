﻿using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.DTOS;
using Mango.Services.AuthAPI.Service.IService;
using Mango.Services.CouponAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly APIResponse _apiResponse;
        private readonly IConfiguration? _configuration;
        private string? _secretKey;

        public AuthAPIController(IAuthService service, IConfiguration configuration)
        {
            _service = service;
            _secretKey = configuration.GetValue<string>("");
            _apiResponse = new();
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginRequestDTO) 
        {
            LoginResponseDTO loginResponse = await _service.Login(loginRequestDTO);
            if (loginResponse.userDTO == null) 
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessage = "username or password is not correct";
                return BadRequest(_apiResponse);
            }

            _apiResponse.IsSuccess = true;
            _apiResponse.Result = loginResponse;
            return Ok(loginResponse);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            try
            {
                var userDTO = await _service.Register(registerRequestDTO);

                if (userDTO.Email != null)
                
                    _apiResponse.StatusCode = HttpStatusCode.OK;
                    _apiResponse.IsSuccess = true;
                    return _apiResponse;

            }
            catch (Exception ex) 
            {
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessage = ex.Message;
                return _apiResponse;
            }
        }
    }
}