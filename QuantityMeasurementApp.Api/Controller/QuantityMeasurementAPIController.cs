using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppBusinessLayer.Interface;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace QuantityMeasurementApp.Api.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityMeasurementAPIController : ControllerBase
    {
        private readonly IQuantityMeasurementService Service;

        public QuantityMeasurementAPIController(IQuantityMeasurementService service)
        {
            Service = service;
        }

        // ── COMPARE ──────────────────────────────────────────────
        [HttpPost("compare")]
        public IActionResult Compare([FromBody] QuantityInputDTO input)
        {
            if (input.QuantityOne == null || input.QuantityTwo == null ||
                string.IsNullOrWhiteSpace(input.QuantityOne.Unit) ||
                string.IsNullOrWhiteSpace(input.QuantityTwo.Unit))
            {
                return BadRequest(new { message = "Invalid input. Please provide valid quantities and units." });
            }

            int userId = GetUserId();
            var result = Service.Compare(input.QuantityOne, input.QuantityTwo, userId);
            return Ok(result);
        }

        // ── ADD ───────────────────────────────────────────────────
        [HttpPost("add")]
        public IActionResult Add([FromBody] QuantityInputDTO input)
        {
            if (input.QuantityOne == null || input.QuantityTwo == null ||
                string.IsNullOrWhiteSpace(input.QuantityOne.Unit) ||
                string.IsNullOrWhiteSpace(input.QuantityTwo.Unit))
            {
                return BadRequest(new { message = "Invalid input. Please provide valid quantities and units." });
            }

            int userId = GetUserId();
            var result = Service.Add(input.QuantityOne, input.QuantityTwo, userId);
            return Ok(result);
        }

        // ── SUBTRACT ──────────────────────────────────────────────
        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] QuantityInputDTO input)
        {
            if (input.QuantityOne == null || input.QuantityTwo == null ||
                string.IsNullOrWhiteSpace(input.QuantityOne.Unit) ||
                string.IsNullOrWhiteSpace(input.QuantityTwo.Unit))
            {
                return BadRequest(new { message = "Invalid input. Please provide valid quantities and units." });
            }

            int userId = GetUserId();
            var result = Service.Subtract(input.QuantityOne, input.QuantityTwo, userId);
            return Ok(result);
        }

        // ── DIVIDE ────────────────────────────────────────────────
        // BUG FIX: Original code only validated QuantityOne — divide needs both quantities.
        [HttpPost("divide")]
        public IActionResult Divide([FromBody] QuantityInputDTO input)
        {
            if (input.QuantityOne == null || input.QuantityTwo == null ||
                string.IsNullOrWhiteSpace(input.QuantityOne.Unit) ||
                string.IsNullOrWhiteSpace(input.QuantityTwo.Unit))
            {
                return BadRequest(new { message = "Invalid input. Please provide both quantities and units." });
            }

            int userId = GetUserId();
            var result = Service.Divide(input.QuantityOne, input.QuantityTwo, userId);
            return Ok(result);
        }

        // ── CONVERT ───────────────────────────────────────────────
        // BUG FIX: targetUnit moved from query-string into the request body so the
        // frontend's JSON-only fetch works correctly (no mixed body+query issues).
        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConvertDTO input)
        {
            if (input.QuantityOne == null || string.IsNullOrWhiteSpace(input.QuantityOne.Unit))
            {
                return BadRequest(new { message = "Invalid input. Please provide a valid quantity and unit." });
            }

            if (string.IsNullOrWhiteSpace(input.TargetUnit))
            {
                return BadRequest(new { message = "Target unit is required." });
            }

            int userId = GetUserId();
            var result = Service.Convert(input.QuantityOne, input.TargetUnit, userId);
            return Ok(result);
        }

        // ── HISTORY ───────────────────────────────────────────────
        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            int userId = GetUserId();
            var history = Service.GetHistory(userId);
            return Ok(history);
        }

        // ── HELPERS ───────────────────────────────────────────────
        private int GetUserId() =>
            int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    }
}