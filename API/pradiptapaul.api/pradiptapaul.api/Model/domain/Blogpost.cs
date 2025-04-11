namespace pradiptapaul.api.Model.domain
{
    public class Blogpost
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string Shortdescription { get; set; }

        public string Context { get; set; }

        public string FeatureImageUrl { get; set; }

        public string UrlHandle { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Author { get; set; }

        public string IsVisible { get; set; }
    }
}
