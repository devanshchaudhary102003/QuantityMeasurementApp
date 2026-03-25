using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppBusinessLayer.Service;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppRepositoryLayer.Database;
using QuantityMeasurementAppModelLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using QuantityMeasurementAppRepositoryLayer.Interface;

namespace QuantityMeasurementApp.Api.Controller
{
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
        public IActionResult Compare([FromBody] QuantityInputDTO input,int userId)
        {
            if(input.QuantityOne == null || input.QuantityTwo == null || input.QuantityOne.Unit == null || input.QuantityTwo.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }

            var result = Service.Compare(input.QuantityOne, input.QuantityTwo, userId);
            return Ok(result);
         }

        [HttpPost("add")]
        public IActionResult Add([FromBody] QuantityInputDTO input,int userId)
        {
            if(input.QuantityOne == null || input.QuantityTwo == null || input.QuantityOne.Unit == null || input.QuantityTwo.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }

            var result = Service.Add(input.QuantityOne,input.QuantityTwo,userId);
            return Ok(result);
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] QuantityInputDTO input,int userId)
        {
            if(input.QuantityOne == null || input.QuantityTwo == null || input.QuantityOne.Unit == null || input.QuantityTwo.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }

            var result = Service.Subtract(input.QuantityOne,input.QuantityTwo,userId);
            return Ok(result);
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] QuantityInputDTO input,double divisor,int userId)
        {
            if(input.QuantityOne == null || input.QuantityOne.Unit == null)
            {
                return BadRequest("Invalid input. Please provide valid quantity and units.");
            }

            var result = Service.Divide(input.QuantityOne,divisor,userId);
            return Ok(result);
        }

        [HttpGet("history")]
        public IActionResult GetHistory(int userId)
        {
            var history = Service.GetHistory(userId);
            return Ok(history);
        }
    }
}
