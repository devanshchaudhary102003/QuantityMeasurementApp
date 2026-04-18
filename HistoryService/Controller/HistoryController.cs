using HistoryService.DTOs;
using HistoryService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HistoryService.Controller
{
    [Route("api/history")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _service;

        public HistoryController(IHistoryService service)
        {
            _service = service;
        }

        private int GetUserId()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return claim != null ? int.Parse(claim) : 0;
        }

        // POST api/history  — save a new history entry (called by QMAOperationService or internal)
        [HttpPost]
        public IActionResult SaveHistory([FromBody] SaveHistoryDTO dto)
        {
            _service.SaveHistory(dto);
            return Ok(new { message = "History saved" });
        }

        // GET api/history  — AUTH REQUIRED
        [Authorize]
        [HttpGet]
        public IActionResult GetHistory()
        {
            var history = _service.GetHistory(GetUserId());
            return Ok(history);
        }

        // DELETE api/history  — AUTH REQUIRED
        [Authorize]
        [HttpDelete]
        public IActionResult DeleteHistory()
        {
            _service.DeleteHistory(GetUserId());
            return Ok(new { message = "History deleted successfully" });
        }

        // GET api/history/operation/{operationType}
        [Authorize]
        [HttpGet("operation/{operationType}")]
        public IActionResult GetHistoryByOperation(string operationType)
        {
            var history = _service.GetHistoryByOperation(GetUserId(), operationType);
            return Ok(history);
        }

        // GET api/history/type/{measurementType}
        [Authorize]
        [HttpGet("type/{measurementType}")]
        public IActionResult GetHistoryByType(string measurementType)
        {
            var history = _service.GetHistoryByType(GetUserId(), measurementType);
            return Ok(history);
        }

        // GET api/history/stats
        [Authorize]
        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            var stats = _service.GetStats(GetUserId());
            return Ok(stats);
        }
    }
}
