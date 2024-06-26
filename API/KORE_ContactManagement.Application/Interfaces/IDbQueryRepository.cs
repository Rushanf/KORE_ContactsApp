﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Application.Interfaces
{
    public interface IDbQueryRepository<T>
    {
        IEnumerable<T> GetAll();
		T Get(int id);
    }
}
