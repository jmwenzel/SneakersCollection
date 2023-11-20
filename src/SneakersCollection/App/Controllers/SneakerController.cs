using Microsoft.AspNetCore.Mvc;
using SneakersCollection.API.App.DTOs;
using SneakersCollection.API.App.Services;
using SneakersCollection.API.Models;
using System;
using System.Collections.Generic;

namespace SneakersCollection.API.App.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route(Config.ROUTE_PREFFIX + "/v{version:apiVersion}/sneaker")]
    public class SneakerController : ControllerBase
    {
        private readonly ISneakerService _sneakerService;

        public SneakerController(ISneakerService sneakerService)
        {
            _sneakerService = sneakerService;
        }

        [HttpPost("create")]
        public IActionResult CreateSneaker(Guid userId, [FromBody] SneakerDto sneakerDto)
        {
            try
            {
                _sneakerService.CreateSneaker(userId, sneakerDto);
                return Ok(new { Message = "Sneaker created successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                // Handle other unexpected errors
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("list")]
        public IActionResult ListSneakers(Guid userId)
        {
            try
            {
                return Ok(_sneakerService.GetAllSneakers(userId));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                // Handle other unexpected errors
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{userId}/{searchTerm}")]
        public IActionResult SearchSneakers(Guid userId, string searchTerm)
        {
            try
            {
                return Ok(_sneakerService.SearchSneakers(userId, searchTerm));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                // Handle other unexpected errors
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateSneaker(Guid userId, [FromBody] SneakerDto sneakerDto)
        {
            try
            {
                _sneakerService.UpdateSneaker(userId, sneakerDto);
                return Ok(new { Message = "Sneaker updated successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                // Handle other unexpected errors
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
