﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.DAL.Repositories.Base
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }

        ICategoryRepository CategoryRepository { get; set; }

        IAuthenticationRepository AuthenticationRepository { get; set; }

        IUserRepository UserRepository { get; set; }

        IGroupRepository GroupRepository { get; set; }
    }
}
