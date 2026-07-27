namespace Cataloger.Api.Features.Books.Publishers.Create {
    public class Request {
        public string Name { get; set; } = string.Empty;
    }

    public class Response {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
