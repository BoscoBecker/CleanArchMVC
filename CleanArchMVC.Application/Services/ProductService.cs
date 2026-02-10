using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Application.Products.Queries;
using MediatR;

namespace CleanArchMVC.Application.Services
{
    public class ProductService(IMapper mapper, IMediator mediator) : IProductServices
    {
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        public async Task AddAsync(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto) ?? throw new ApplicationException("Entity could not be loaded.");
            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var prodductById = new GetProductByIdQuery(id) ?? throw new ApplicationException("Entity could not be loaded.");
            var result = await _mediator.Send(prodductById);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery() ?? throw new ApplicationException("Entity could not be loaded.");
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task RemoveAsync(int id)
        {
            var productRemoveCommand = new GetProductByIdQuery(id) ?? throw new ApplicationException("Entity could not be loaded.");
            await _mediator.Send(productRemoveCommand);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto) ?? throw new ApplicationException("Entity could not be loaded.");
            await _mediator.Send(productUpdateCommand);
        }
    }
}
