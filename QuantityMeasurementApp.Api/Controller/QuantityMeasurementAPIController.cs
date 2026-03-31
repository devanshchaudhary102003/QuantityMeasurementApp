using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppBusinessLayer.Service;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppRepositoryLayer.Database;
using QuantityMeasurementAppModelLayer.Entity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using QuantityMeasurementAppRepositoryLayer.Interface;
using Microsoft.AspNetCore.Authorization;

namespace QuantityMeasurementApp.Api.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityMeasurementAPIController : ControllerBase
    {
        private readonly IQuantityMeasurementService Service;

        public QuantityMeasurementAPIController(IQuantityMeasurementService Service)
        {
            this.Service =Service;
        }

        [HttpPost("compare")]
        public IActionResult Compare([FromBody] QuantityInputDTO input)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if(input.QuantityOne == null || input.QuantityTwo == null || input.QuantityOne.Unit == null || input.QuantityTwo.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }

            var result = Service.Compare(input.QuantityOne, input.QuantityTwo, userId);
            return Ok(result);
         }

        [HttpPost("add")]
        public IActionResult Add([FromBody] QuantityInputDTO input)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if(input.QuantityOne == null || input.QuantityTwo == null || input.QuantityOne.Unit == null || input.QuantityTwo.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }

            var result = Service.Add(input.QuantityOne,input.QuantityTwo,userId);
            return Ok(result);
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] QuantityInputDTO input)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if(input.QuantityOne == null || input.QuantityTwo == null || input.QuantityOne.Unit == null || input.QuantityTwo.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }

            var result = Service.Subtract(input.QuantityOne,input.QuantityTwo,userId);
            return Ok(result);
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] QuantityInputDTO input)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if(input.QuantityOne == null || input.QuantityOne.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }

            var result = Service.Divide(input.QuantityOne,input.QuantityTwo,userId);
            return Ok(result);
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] QuantityInputDTO input, string targetUnit)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (input.QuantityOne == null || string.IsNullOrWhiteSpace(input.QuantityOne.Unit))
            {
                return BadRequest("Invalid input. Please provide valid quantity and unit.");
            }

            if (string.IsNullOrWhiteSpace(targetUnit))
            {
                return BadRequest("Target unit is required.");
            }

            var result = Service.Convert(input.QuantityOne, targetUnit, userId);
            return Ok(result);
        }


        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var history = Service.GetHistory(userId);
            return Ok(history);
        }
    }
}
