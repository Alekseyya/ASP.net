using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.WebUi.Models;

namespace WebStore.WebUi.App_Start
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ProductProfile());                
            });
        }
    }
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<service.ProductDataContract, IndexProductViewModel>();
        }
        
    }
}