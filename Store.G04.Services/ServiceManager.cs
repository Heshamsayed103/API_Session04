using AutoMapper;
using Store.G04.Domain.Contracts;
using Store.G04.Services.Abstractions;
using Store.G04.Services.Abstractions.Products;
using Store.G04.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Services
{
    public class ServiceManager(IUnitOfWork _unitOfWork, IMapper _mapper) : IServiceManager
    {
        public IProductService ProductService { get; } = new ProductService(_unitOfWork, _mapper);
    }
}
