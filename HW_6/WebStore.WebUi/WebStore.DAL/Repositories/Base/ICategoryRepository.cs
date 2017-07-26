﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.DAL.Repositories.Base
{
    public interface ICategoryRepository: IBaseRepository<Category>
    {
        Category GetByName(string name);
    }
}
