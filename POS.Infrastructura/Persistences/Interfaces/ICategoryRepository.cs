using POS.Domain.Entities;
using POS.Infrastructura.Commons.Bases;
using POS.Infrastructura.Commons.Bases.Request;

namespace POS.Infrastructura.Persistences.Interfaces
{
    public interface ICategoryRepository
    {
        Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters);
        Task<IEnumerable<Category>> ListSelectCategories();
        Task<Category> CategoryById(int categoryId);
        Task<bool> RegisterCategory(Category category);
        Task<bool> EditCategory(Category category);
        Task<bool> RemoveCategrory(int categroryId);
    }
}
