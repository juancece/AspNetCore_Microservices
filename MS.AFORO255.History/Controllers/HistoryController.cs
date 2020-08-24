using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.History.Model;
using MS.AFORO255.History.Service;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using MS.AFORO255.History.DTO;

namespace MS.AFORO255.History.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IHistoryService _historyService;

        public HistoryController(IDistributedCache distributedCache, IHistoryService historyService)
        {
            _distributedCache = distributedCache;
            _historyService = historyService;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> Get(int accountId)
        {
            string _key = $"key-account-{accountId}";
            //string _key = $"key-account";

            var _cache = _distributedCache.GetString(_key);
            List<HistoryResponse> model = null;
            if (_cache == null)
            {
                var result = await _historyService.GetAll();
                model =  result.Where(x => x.AccountId == accountId).ToList();

                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));

                _distributedCache.SetString(_key, Newtonsoft.Json.JsonConvert.SerializeObject(model), options);
            }
            else
            {
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HistoryResponse>>(_cache);
            }

            return Ok(model);
        }

        //[HttpPost()]
        //public async Task<IActionResult> Post([FromBody] HistoryTransaction request)
        //{
        //    await _historyService.Add(request);
        //    return Ok();
        //}
    }
}