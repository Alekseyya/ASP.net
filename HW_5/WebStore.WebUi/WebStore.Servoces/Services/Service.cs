using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL;
using WebStore.DAL.Repositories;
using WebStore.Domain.DataContracts.Service;
using WebStore.Services.Services.Base;

namespace WebStore.Services.Services
{
    //здесь надо подключаться к репозиторию
    public class Service : IService
    {
        ProductPepository productRepo;
        public Service()
        {
            this.productRepo = new ProductPepository();     
        }
        public void CreateProduct(ProductsService item)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            productRepo.Delete(id);
        }

        public ProductsService GetItemProduct(int id)
        {
            var tmpProd = productRepo.GetItem(id);
            var prod = new ProductsService
            {
                Id = tmpProd.Id,
                Name = tmpProd.Name,
                Count = tmpProd.Count
            };
            return prod;
        }

        public List<ProductsService> GetListProducts()
        {
            List<ProductsService> tmpProd = new List<ProductsService>();
            var tt = productRepo.GetList();
            foreach (var prod in productRepo.GetList())
            {
                tmpProd.Add(new ProductsService { Id = prod.Id, Name = prod.Name, Count = prod.Count });
            }
            return tmpProd;
        }

        public void UpdateProduct(ProductsService item)
        {
            var prod = new WebStore.Domain.Entities.Product { Id= item.Id, Name = item.Name, Count=item.Count};
            productRepo.Update(prod);
        }
    }
}
