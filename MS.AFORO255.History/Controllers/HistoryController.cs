using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.History.Model;
using MS.AFORO255.History.Service;

namespace MS.AFORO255.History.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        
        [HttpGet("{accountId}")]
        public async Task<IActionResult> Get(int accountId)
        {
            var result = await _historyService.GetAll();
            return Ok(result.Where(x =>x.AccountId == accountId).ToList());
        }

        // [HttpPost()]
        // public async Task<IActionResult> Post([FromBody] HistoryTransaction historyTransaction)
        // {
        //     await _historyService.Add(historyTransaction);
        //     return Ok();
        // }
    }
}