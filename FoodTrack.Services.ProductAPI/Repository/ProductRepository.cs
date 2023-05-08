using AutoMapper;
using FoodTrack.Services.ProductAPI.DbContexts;
using FoodTrack.Services.ProductAPI.Models;
using FoodTrack.Services.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdate(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductID > 0)
            {
                _applicationDbContext.Update(product);
            }
            else
            {
                _applicationDbContext.Add(product);
            }
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int ProductId)
        {
            try
            {
                Product product = await _applicationDbContext.Products.Where(x => x.ProductID == ProductId).FirstOrDefaultAsync();
                if (product == null)
                {
                    return false;
                }
                _applicationDbContext.Products.Remove(product);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _applicationDbContext.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task<ProductDto> GetProductsById(int ProductId)
        {
            Product product = await _applicationDbContext.Products.Where(x => x.ProductID == ProductId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }
    }
}

