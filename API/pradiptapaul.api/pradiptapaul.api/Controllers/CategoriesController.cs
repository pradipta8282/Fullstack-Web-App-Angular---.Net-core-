
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pradiptapaul.api.DATA;
using pradiptapaul.api.Model.domain;
using pradiptapaul.api.Model.domain.DTO;
using pradiptapaul.api.Repository.Interface;
using System.Drawing;
using System.Net.NetworkInformation;

namespace pradiptapaul.api.Controllers
{
    //https://localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {


        private readonly ApplicationDBContext dbContext;
        private readonly IcategoryRepository categoryRepository;

        // ✅ Use only one constructor
        public CategoriesController(ApplicationDBContext dbContext, IcategoryRepository categoryRepository)
        {
            this.dbContext = dbContext;
            this.categoryRepository = categoryRepository;
        }



        [HttpPost]//Specifies that this action method will handle HTTP POST requests.
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO req)//public → The method is accessible from outside.

        //async Task<IActionResult> →

        //async → Enables asynchronous programming for non-blocking execution.

        //Task<IActionResult> →

        //Task<> means it is asynchronous.

        //IActionResult allows returning different HTTP responses (e.g., Ok(), BadRequest()).

        //CreateCategoryRequestDTO req

        //This is the input DTO (Data Transfer Object).

        //It contains only the necessary fields required from the user (e.g., Name, UrlHandle).



        // here using the category  request dto.//getting the name and urlhndl from user.and we have make this CreateCategoryRequestDTO class with this two property.
        {
            //We are using ANgular application so angular ui application will send us the request dto and the api will take this and transform into a domain model to then submit it to the DB.
            var category = new Category
            //Creates a new domain model object (Category) from the incoming DTO (CreateCategoryRequestDTO).

            //This step is necessary because:

            //The API receives data in DTO format.

            //The domain model represents the actual database entity.

            //Mapping ensures we only include necessary properties.
            {
                //Map DTO to a Domain Model.
                Name = req.Name,
                UrlHandle = req.UrlHandle,
            };

            await categoryRepository.CreateAsync(category);//we are abstracting the implementation of the repository.Controller has no idea how the repository able to save changes inside db.
                                                           //Calls the CreateAsync method of categoryRepository (which is an instance of ICategoryRepository).Passes the category object to be saved in the database. Waits (await) for the operation to complete before moving to the next line.The CreateAsync method is defined inside the repository class (CategoryRepository), which interacts with the database using Entity Framework Core.Uses Task<Category> → This means the method runs asynchronously and returns a Category object.


            //dbContext.Categories.AddAsync(category);

            //Adds the new category object to the Categories table.

            //AddAsync() is an asynchronous method for performance optimization.

            //await dbContext.SaveChangesAsync();

            //Saves changes in the database.

            //await ensures the execution waits for database operations to complete before continuing.

            //Domain model to DTO
            var response = new CategoryDTO
            //This step converts the database entity (Category) back into a DTO (CategoryDTO).

            //Why this step?

            //The API should not expose the entire domain model (security & flexibility).

            //DTOs help control the data being returned.


            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,

            };
            return Ok(category);//It sends the created category back to the client.
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryRepository.GetAllAsync();

            //map domain model to dto
            var response = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                response.Add(new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle,
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryByID([FromRoute] Guid id)
        {
            var existingCategory = await categoryRepository.GetByID(id);
            if (existingCategory is null)
            {
                return NotFound();
            }
            var response = new CategoryDTO
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name,
                UrlHandle = existingCategory.UrlHandle
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id,UpdatecategoryRequestDto request)

        {
            //convert dto to domain model
            var category = new Category
            {
                    Id = id,
                    Name=request.Name,
                    UrlHandle=request.UrlHandle
            };
           category= await categoryRepository.UpdateAsync(category);
            if (category is null)
            {
                return NotFound();
            }
            //convert domain model to dto
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Deletecategory([FromRoute] Guid id)
        {
            var category = await categoryRepository.DeleteAsync(id);
            if (category is null)
            {
                return NotFound();
            }
            //convert domain model to DTO
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        
        
        }

    }

}
