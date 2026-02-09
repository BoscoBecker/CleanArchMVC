using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;

namespace CleanArchMVC.Application.Services
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductServices
    {
        private readonly IProductRepository _productRepository = productRepository;
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
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(productEntity);
        }
    }
}
