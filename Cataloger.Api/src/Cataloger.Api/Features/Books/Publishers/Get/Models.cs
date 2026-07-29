namespace Cataloger.Api.Features.Books.Publishers.Get {
    public class Request {
        public Guid Id { get; set; }
    }

    public class Response {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
