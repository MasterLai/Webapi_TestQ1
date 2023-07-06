using Microsoft.AspNetCore.Mvc;
using Infrastructure.DTO;
using Infrastructure.Entities;
using Application.Interface;
using Infrastructure;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly TestContext db;

        private readonly ILogger<TestController> _logger;

        public  TestController(TestContext db, ILogger<TestController> logger)
        {
            this.db = db;
            _logger = logger;
        }
        

        [HttpGet(Name = "GetTest")]
        public async Task<List<Test>> Get()
        {
            HttpClient httpClient = new();
            List<Gov>? dataList = httpClient.GetFromJsonAsync<List<Gov>>("https://odws.hccg.gov.tw/001/Upload/25/opendataback/9059/870/8bfb5f8a-2748-44da-a188-6e568987676b.json").Result;

            List<Test> insertList = new List<Test>();
            foreach(var data in dataList)
            {

                Test model = new Test();
                model.Associationtype = data.農會漁會別;
                model.Branchtype = data.總部分支機構別;
                model.Financialcode = data.金融代號;
                model.Postalcode = data.郵遞區號;
                model.County = data.所在縣市;
                model.Address = data.住址;
                model.Telepon = data.電話;
                insertList.Add(model);
            }
            await db.Tests.AddRangeAsync(insertList);
            await db.SaveChangesAsync();
            var result = db.Tests.AsQueryable().ToList();

            return result;
        }
    }
}