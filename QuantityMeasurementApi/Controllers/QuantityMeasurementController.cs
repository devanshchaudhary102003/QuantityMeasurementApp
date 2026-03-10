using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;

namespace QuantityMeasurementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuantityMeasurementController : ControllerBase
    {
        private readonly IQuantityMeasurementService _service;

        public QuantityMeasurementController(IQuantityMeasurementService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost("compare")]
        public IActionResult Compare([FromBody] CompareRequest request)
        {
            var result = _service.Compare(request.Left, request.Right);
            return Ok(result);
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConvertRequest request)
        {
            var result = _service.Convert(request.Source, request.TargetUnit);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] BinaryRequest request)
        {
            var result = _service.Add(request.Left, request.Right);
            return Ok(result);
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] BinaryRequest request)
        {
            var result = _service.Subtract(request.Left, request.Right);
            return Ok(result);
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] BinaryRequest request)
        {
            var result = _service.Divide(request.Left, request.Right);
            return Ok(result);
        }

        [HttpGet("history")]
        public IActionResult History()
        {
            var result = _service.GetHistory();
            return Ok(result);
        }
    }

    public class CompareRequest
    {
        public QuantityDTO Left { get; set; } = new();
        public QuantityDTO Right { get; set; } = new();
    }

    public class BinaryRequest
    {
        public QuantityDTO Left { get; set; } = new();
        public QuantityDTO Right { get; set; } = new();
    }

    public class ConvertRequest
    {
        public QuantityDTO Source { get; set; } = new();
        public string TargetUnit { get; set; } = string.Empty;
    }
}