using AutoMapper;

using Store.G04.Services.Specifications.Products;


namespace Store.G04.Services.Products
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {

        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            //var spec = new BaseSpecifications<int, Product>(null);
            //spec.Includes.Add(P => P.Brand);
            //spec.Includes.Add(P => P.Type);

            var spec = new ProductsWithBrandAndTypeSpecifications();

            var products = await _unitOfWork.GetRepository<int, Product>().GetAllAsync(spec);
            var result = _mapper.Map<IEnumerable<ProductResponse>>(products);
            return result;
        }

        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            var spec = new ProductsWithBrandAndTypeSpecifications(id);


            var product = await _unitOfWork.GetRepository<int, Product>().GetAsync(spec);
            var result = _mapper.Map<ProductResponse>(product);
            return result;
        }

        public async Task<IEnumerable<BrandTypeResponse>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepository<int, ProductBrand>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<BrandTypeResponse>>(brands);
            return result;
        }

        public async Task<IEnumerable<BrandTypeResponse>> GetAllTypeAsync()
        {
            var types = await _unitOfWork.GetRepository<int, ProductType>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<BrandTypeResponse>>(types);
            return result;
        }

        
    }
}
