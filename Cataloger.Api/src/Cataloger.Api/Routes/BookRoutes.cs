namespace Cataloger.Api.Routes {
    public class BookRoutes {
        private const string Base = ApiRoutes.Api + "/books";
        private const string BaseTag = "Books";

        public const string Publishers = Base + "/publishers";
        public const string PublishersTag = BaseTag + ":Publishers";

        public const string Authors = Base + "/authors";
        public const string AuthorsTag = BaseTag + ":Authors";
    }
}
