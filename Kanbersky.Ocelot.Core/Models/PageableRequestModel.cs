namespace Kanbersky.Ocelot.Core.Models
{
    public class PageableRequestModel
    {
        public int? PageSize { get; set; } = 10;

        public bool IsOrderByDesc { get; set; }

        public string OrderByField { get; set; }

        public int? Page { get; set; } = 1;
    }
}
