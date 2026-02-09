using CleanArchMVC.Application.Products.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) => await _productRepository.GetByIdAsync(request.Id);                    
    }
}
