using CleanArchMVC.Application.DTOs;

namespace CleanArchMVC.Application.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetByIdAsync(int? id);
        Task AddAsync(CategoryDTO categoryDto);
        Task UpdateAsync(CategoryDTO categoryDto);
        Task RemoveAsync(int? id);

    }
}
