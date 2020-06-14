using System;

namespace Kanbersky.Ocelot.Core.Helpers.Pagination
{
    public class SortableAttribute : Attribute
    {
        public string OrderBy { get; set; }
    }
}
