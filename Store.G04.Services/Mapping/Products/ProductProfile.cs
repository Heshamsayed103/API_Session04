using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Store.G04.Domain.Entities.Products;
using Store.G04.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Services.Mapping.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile(IConfiguration configuration)
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(D => D.Brand, O => O.MapFrom(S => S.Brand.Name))
                .ForMember(D => D.Type, O => O.MapFrom(S => S.Type.Name))
                //.ForMember(D => D.PictureUrl, O => O.MapFrom(S => $"{configuration["BaseUrl"]}/{S.PictureUrl}"));
                .ForMember(D => D.PictureUrl, O => O.MapFrom(new ProductPictureUrlResolver(configuration)));

            CreateMap<ProductBrand, BrandTypeResponse>();
            CreateMap<ProductType, BrandTypeResponse>();
        }
    }
}
