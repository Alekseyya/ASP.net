using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL;
using WebStore.DAL.Repositories;
using WebStore.DAL.Repositories.Base;
using WebStore.Domain.DataContracts.Service;
using WebStore.Domain.Entities;
using WebStore.Services.Services.Base;

namespace WebStore.Services.Services
{
    //здесь надо подключаться к репозиторию
    public class Service : IService
    {
        IUnitOfWork _unitOfWork;
        
        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
                

        /// <summary>
        /// Получить список категорий
        /// </summary>
        /// <returns>IEnumerable<CategoryDataContract></returns>
        public IEnumerable<CategoryDataContract> GetCategories()
        {
            Mapper.Initialize(o => o.CreateMap<Category, CategoryDataContract>());
            var categoriesDataContract = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDataContract>>(_unitOfWork.CategoryRepository.GetList());
            return categoriesDataContract.ToList();
        }
        /// <summary>
        /// Получение категории по имени
        /// </summary>
        /// <param name="name">Имя категории</param>
        /// <returns>CategoryDataContract</returns>
        public CategoryDataContract GetCategory(string name)
        {
            Mapper.Initialize(o => o.CreateMap<Category, CategoryDataContract>());
            var categoryDataContract = Mapper.Map<Category, CategoryDataContract>(_unitOfWork.CategoryRepository.GetByName(name));
            return categoryDataContract;
        }
        /// <summary>
        /// Получение категории по id
        /// </summary>
        /// <param name="id">id категории</param>
        /// <returns>CategoryDataContract</returns>
        public CategoryDataContract GetCategory(int id)
        {
            Mapper.Initialize(o => o.CreateMap<Category, CategoryDataContract>());
            var categoryDataContract = Mapper.Map<Category, CategoryDataContract>(_unitOfWork.CategoryRepository.GetItem(id));
            return categoryDataContract;
        }

        /// <summary>
        /// Получение товара по id
        /// </summary>
        /// <param name="id">Id товара</param>
        /// <returns>ProductDataContract</returns>
        public ProductDataContract GetProduct(int id)
        {
            Mapper.Initialize(o => o.CreateMap<Product, ProductDataContract>());
            var productDataContract = Mapper.Map<Product, ProductDataContract>(_unitOfWork.ProductRepository.GetItem(id));
            return productDataContract;
        }

        public void UpdateProduct(ProductDataContract product)
        {
            Mapper.Initialize(o => o.CreateMap<ProductDataContract, Product>()
                .ForMember("Category", opt => opt.Ignore()));                
            var productDataContract = Mapper.Map<ProductDataContract, Product>(product);
            productDataContract.CategoryId = _unitOfWork.CategoryRepository.GetByName(product.Category).Id;
            _unitOfWork.ProductRepository.Update(productDataContract);           
        }

        /// <summary>
        /// Получение списка товаров
        /// </summary>
        /// <returns>List<ProductDataContract></returns>
        public List<ProductDataContract> GetProducts() 
        {
            Mapper.Initialize(o => o.CreateMap<Product, ProductDataContract>()
                    .ForMember("Category", opt => opt.MapFrom(c=>c.Category.Name)));
            var product = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDataContract>>(_unitOfWork.ProductRepository.GetList());
            return product.ToList();
            #region Рабочий код
            //List<ProductDataContract> tmpProd = new List<ProductDataContract>();
            //var tt = _unitOfWork.ProductRepository.GetList();
            //foreach (var prod in _unitOfWork.ProductRepository.GetList())
            //{
            //    tmpProd.Add(
            //        new ProductDataContract
            //        {
            //            Id = prod.Id,
            //            Name = prod.Name,
            //            Descriptions = prod.Descriptions,
            //            Price = prod.Price,
            //            IsDeleted = prod.IsDeleted,
            //            Category = prod.Category.Name,
            //            Count = prod.Count
            //        });
            //}
            //return tmpProd; 
            #endregion

        }

        

        #region oldService
        //ProductsRepository productRepo;
        //public Service()
        //{
        //    this.unitOfWork = new UnitOfWork();
        //}
        //public void CreateProduct(ProductsService item)
        //{
        //    //var prod = new WebStore.Domain.Entities.Product { Id=item.Id, Name = item.Name, Count = item.Count}
        //}

        //public void DeleteProduct(int id)
        //{
        //    productRepo.Delete(id);
        //}

        //public ProductsService GetItemProduct(int id)
        //{
        //    var tmpProd = productRepo.GetItem(id);
        //    var prod = new ProductsService
        //    {
        //        Id = tmpProd.Id,
        //        Name = tmpProd.Name,
        //        Count = tmpProd.Count
        //    };
        //    return prod;
        //}

        //public List<ProductsService> GetListProducts()
        //{
        //    List<ProductsService> tmpProd = new List<ProductsService>();
        //    var tt = productRepo.GetList();
        //    foreach (var prod in productRepo.GetList())
        //    {
        //        tmpProd.Add(new ProductsService { Id = prod.Id, Name = prod.Name, Count = prod.Count });
        //    }
        //    return tmpProd;
        //}

        //public void UpdateProduct(ProductsService item)
        //{
        //    var product = productRepo.GetList().FirstOrDefault(o => o.Id == item.Id);
        //    var tmp = new WebStore.Domain.Entities.Product { Id = product.Id, Name = item.Name, Count = item.Count };
        //    productRepo.Update(tmp);
        //} 
        #endregion

    }
}
