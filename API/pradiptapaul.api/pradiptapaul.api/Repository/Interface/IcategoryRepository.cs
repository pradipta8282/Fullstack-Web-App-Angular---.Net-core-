using pradiptapaul.api.Model.domain;

namespace pradiptapaul.api.Repository.Interface
{
    public interface IcategoryRepository
    {
         Task<Category> CreateAsync(Category category);   //here we will define the only defination of the method not actual implementation
        Task<IEnumerable<Category> >GetAllAsync();
        Task<Category?>GetByID(Guid id);

        Task<Category?>UpdateAsync(Category category);
        

         Task<Category?> DeleteAsync(Guid id);
    }
}
