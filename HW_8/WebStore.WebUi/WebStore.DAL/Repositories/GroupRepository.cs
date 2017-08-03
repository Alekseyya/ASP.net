using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.DAL.Repositories.Base;
using WebStore.Domain.Entities;

namespace WebStore.DAL.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly WebStoreContext _context;

        public GroupRepository(WebStoreContext context)
        {
            _context = context;
        }
        public void Create(Group item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Group GetItem(int id)
        {
            return _context.Groups.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Group> GetList()
        {
            return _context.Groups.ToArray();
        }

        public void Update(Group item)
        {
            throw new NotImplementedException();
        }

        
    }
}
