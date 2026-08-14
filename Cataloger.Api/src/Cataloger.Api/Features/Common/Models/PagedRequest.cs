namespace Cataloger.Api.Features.Common.Models {
    public class PagedRequest {
        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 12;
        public bool Descending { get; init; } = false;
    }
}
