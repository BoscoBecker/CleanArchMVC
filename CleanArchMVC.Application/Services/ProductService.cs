using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Application.Services
{
    public class ProductService(Domain.Interfaces.IProductRepository productRepository, IMapper mapper) : Interfaces.IProductServices
    {
        private readonly Domain.Interfaces.IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task AddAsync(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var productEntity = await _productRepository.GetProductCategoryByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsEntity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task RemoveAsync(int id)
        {
            var productsEntity = await _productRepository.GetProductCategoryByIdAsync(id);
            await _productRepository.RemoveAsync(productsEntity);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var productsEntity = await _productRepository.GetProductsAsync();
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(productEntity);
        }
    }
}
