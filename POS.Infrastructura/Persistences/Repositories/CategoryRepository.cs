using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructura.Commons.Bases;
using POS.Infrastructura.Commons.Bases.Request;
using POS.Infrastructura.Persistences.Contexts;
using POS.Infrastructura.Persistences.Interfaces;

namespace POS.Infrastructura.Persistences.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly PosContext _context;
        public CategoryRepository(PosContext context)
        {
            _context = context;
        }
        public async Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Category>();
            var categories = (from c in _context.Categories
                              where c.AuditDeleteUser == null && c.AuditDeleteDate == null
                              select c).AsNoTracking().AsQueryable();
            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        categories = categories.Where(x => x.Name!.Contains(filters.TextFilter));
                        break;
                    case 2:
                        categories = categories.Where(x=>x.Description!.Contains(filters.TextFilter));
                        break;
                }
            }
            if(filters.StateFilter is not null)
            {
                categories = categories.Where(x => x.State.Equals(filters.StateFilter));
            }
            
            if(string.IsNullOrEmpty(filters.StartDate)&& !string.IsNullOrEmpty(filters.EndDate))
            {
                categories = categories.Where(x=>x.AuditCreateDate>= Convert.ToDateTime(filters.StartDate) && x.AuditCreateDate<= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null) filters.Sort = "CategoryId"; 
            
            response.TotalRecords = await categories.CountAsync();
            response.Items = await Ordering(filters, categories, !(bool)filters.Download).ToListAsync();
            return response;

        }
        public Task<IEnumerable<Category>> ListSelectCategories()
        {
            throw new NotImplementedException();
        }
        public Task<Category> CategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterCategory(Category category)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditCategory(Category category)
        {
            throw new NotImplementedException();
        }
        public Task<bool> RemoveCategrory(int categroryId)
        {throw new NotImplementedException();
        }
    }
}
