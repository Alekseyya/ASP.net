using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.DAL.Repositories;
using WebStore.DAL.Repositories.Base;

namespace WebStore.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebStoreContext _context;
        

        public UnitOfWork()
        {
            _context = new WebStoreContext();
            ProductRepository = new ProductPepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            AuthenticationRepository = new AuthenticationRepository(_context);
            UserRepository = new UserRepository(_context);
            GroupRepository = new GroupRepository(_context);
            OrderRepository = new OrderRepository(_context);
            OrderDetailsRepository = new OrderDetailsRepository(_context);
        }

        public UnitOfWork(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
        }

        public IProductRepository ProductRepository{get; set;}

        public ICategoryRepository CategoryRepository { get; set; }

        public IAuthenticationRepository AuthenticationRepository { get; set; }

        public IUserRepository UserRepository { get; set; }

        public IGroupRepository GroupRepository { get; set; }

        public IOrderRepository OrderRepository { get; set; }

        public IOrderDetailsRepository OrderDetailsRepository { get; set; }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
    }
}
