using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakersCollection.API.App.DTOs;
using SneakersCollection.API.App.Services;
using SneakersCollection.API.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;

namespace SneakersCollection.API.App.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route(Config.ROUTE_PREFFIX + "/v{version:apiVersion}/auth")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] SignInRequest request)
        {
            try
            {
                var token = _authAppService.SignIn(request);
                return Ok(new { Token = token });
            }
            catch (AuthenticationException ex)
            {
                // Handle authentication failure
                return Unauthorized(ex.Message);
            }
            catch (Exception)
            {
                // Handle other unexpected errors
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] SignUpRequest request)
        {
            try
            {
                _authAppService.SignUp(request);
                return Ok(new { Message = "Account created successfully" });
            }
            catch (ValidationException ex)
            {
                // Handle validation failure
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                // Handle other unexpected errors
                return StatusCode(500, "Internal server error");
            }
        }

        
    }
}
