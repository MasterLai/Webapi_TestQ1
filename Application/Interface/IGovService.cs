﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;
using Infrastructure.Entities;

namespace Application.Interface
{
    public interface IGovService
    {
        public Task<List<Test>> AddDb(List<Gov> dataList);
    }
}
