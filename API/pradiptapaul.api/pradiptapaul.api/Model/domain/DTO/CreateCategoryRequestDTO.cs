namespace pradiptapaul.api.Model.domain.DTO
{
    public class CreateCategoryRequestDTO
    {
        public string Name { get; set; }

        public string UrlHandle { get; set; }// only copied this 2 property from Category.cs model because the id primary key will not get passed by the user in the HTTPPOST action method.
    }
}
