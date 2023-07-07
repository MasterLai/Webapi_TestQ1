using Application.Interface;
using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Entities;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GovService : IGovService
    {
        IUnitOfWork uw = null;
        public GovService(IUnitOfWork _uw)
        {
            uw = _uw;
        }

        public async Task<List<Test>> AddDb(List<Gov> dataList)
        {
            foreach(var data in dataList)
            {

                Test model = new Test();
                model.Associationtype = data.農會漁會別;
                model.Branchtype = data.總部分支機構別;
                model.Financialcode = data.金融代號;
                model.County = data.所在縣市;
                model.Address = data.住址;
                model.Telepon = data.電話;
                uw.GenericRepository<Test>().Add(model);
            }
            uw.Save();
            var result = await uw.GenericRepository<Test>().GetAllAsync();
            return result.ToList();
        }
    }
}
