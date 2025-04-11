using Microsoft.EntityFrameworkCore;
using pradiptapaul.api.DATA;
using pradiptapaul.api.Model.domain;
using pradiptapaul.api.Repository.Interface;

namespace pradiptapaul.api.Repository.Implementation
{
    public class CategoryRepository : IcategoryRepository
    {
        private readonly ApplicationDBContext dbcontext;//this field camn be used inside the CreateAsync method

        public CategoryRepository(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Category> CreateAsync(Category category)//so the class is now implementing the interface.We are taking away the functionality of the DBContext class from the controller.because we are doing the DBContext and saving th data inside the controller that is a bad practice so remove this functionality from the controller and add it to the repository. for this we have to inject the Dbcontext inside the constructor of this class.
        {
            await dbcontext.Categories.AddAsync(category);// to use this CreteAsync we need to inject this using Di in the application so can use this in application
            await dbcontext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteAsync(Guid id)
        {
           var existingCategory =await  dbcontext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory is null)
            {
                return null;
            }
            dbcontext.Categories.Remove(existingCategory);
            await dbcontext.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
           return  await dbcontext.Categories.ToListAsync();
        }

        public async Task<Category?> GetByID(Guid id)
        {
            return await dbcontext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
          var existingcategory=  await dbcontext.Categories.FirstOrDefaultAsync(x =>x.Id == category.Id);
            if (existingcategory != null)
            {
                dbcontext.Entry(existingcategory).CurrentValues.SetValues(category);
                await dbcontext.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}
