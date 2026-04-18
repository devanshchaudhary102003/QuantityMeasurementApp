using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QMAOperationService.DTOs;
using QMAOperationService.Interfaces;
using System.Security.Claims;

namespace QMAOperationService.Controller
{
    [Route("api/quantity")]
    [ApiController]
    public class QuantityController : ControllerBase
    {
        private readonly IQuantityMeasurementService Service;

        public QuantityController(IQuantityMeasurementService service)
        {
            Service = service;
        }

        // Guest-safe: userId = 0 if not logged in
        private int GetUserId()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return claim != null ? int.Parse(claim) : 0;
        }

        [AllowAnonymous]
        [HttpPost("compare")]
        public async Task<IActionResult> Compare([FromBody] QuantityInputDTO input)
        {
            if (input.QuantityOne == null || input.QuantityTwo == null ||
                string.IsNullOrWhiteSpace(input.QuantityOne.Unit) ||
                string.IsNullOrWhiteSpace(input.QuantityTwo.Unit))
                return BadRequest(new { message = "Invalid input." });

            var result = await Service.Compare(input.QuantityOne, input.QuantityTwo, GetUserId());
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] QuantityInputDTO input)
        {
            if (input.QuantityOne == null || input.QuantityTwo == null ||
                string.IsNullOrWhiteSpace(input.QuantityOne.Unit) ||
                string.IsNullOrWhiteSpace(input.QuantityTwo.Unit))
                return BadRequest(new { message = "Invalid input." });

            var result = await Service.Add(input.QuantityOne, input.QuantityTwo, GetUserId());
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("subtract")]
        public async Task<IActionResult> Subtract([FromBody] QuantityInputDTO input)
        {
            if (input.QuantityOne == null || input.QuantityTwo == null ||
                string.IsNullOrWhiteSpace(input.QuantityOne.Unit) ||
                string.IsNullOrWhiteSpace(input.QuantityTwo.Unit))
                return BadRequest(new { message = "Invalid input." });

            var result = await Service.Subtract(input.QuantityOne, input.QuantityTwo, GetUserId());
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("divide")]
        public async Task<IActionResult> Divide([FromBody] QuantityInputDTO input)
        {
            if (input.QuantityOne == null || input.QuantityTwo == null ||
                string.IsNullOrWhiteSpace(input.QuantityOne.Unit) ||
                string.IsNullOrWhiteSpace(input.QuantityTwo.Unit))
                return BadRequest(new { message = "Invalid input." });

            var result = await Service.Divide(input.QuantityOne, input.QuantityTwo, GetUserId());
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("convert")]
        public async Task<IActionResult> Convert([FromBody] ConvertDTO input)
        {
            if (input.QuantityOne == null || string.IsNullOrWhiteSpace(input.QuantityOne.Unit))
                return BadRequest(new { message = "Invalid input." });
            if (string.IsNullOrWhiteSpace(input.TargetUnit))
                return BadRequest(new { message = "Target unit is required." });

            var result = await Service.Convert(input.QuantityOne, input.TargetUnit, GetUserId());
            return Ok(result);
        }
    }
}
