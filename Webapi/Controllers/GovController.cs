using Microsoft.AspNetCore.Mvc;
using Infrastructure.DTO;
using Infrastructure.Entities;
using Application.Interface;
using Infrastructure;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GovController : ControllerBase
    {
        private readonly TestContext db;

        private readonly ILogger<GovController> _logger;
        private readonly IGovService govService;

        public GovController(TestContext db, ILogger<GovController> logger, IGovService _govService)
        {
            this.db = db;
            _logger = logger;
            govService = _govService;
        }

        // [HttpPost(Name = "PostGov")]
        // public async Task<List<Test>> Post()
        // {
        //     HttpClient httpClient = new();
        //     List<Gov>? result = httpClient.GetFromJsonAsync<List<Gov>>("https://odws.hccg.gov.tw/001/Upload/25/opendataback/9059/870/8bfb5f8a-2748-44da-a188-6e568987676b.json").Result;

        //     var result2 = await govService.AddDb(result);

        //     return result2;
        // }

        // [HttpGet(Name = "GetGov")]
        // public bool Get()
        // {
        //     db.Tests.Any();

        //     return db.Tests.Any();
        // }
    }
}