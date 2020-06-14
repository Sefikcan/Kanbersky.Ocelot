using Kanbersky.Ocelot.Core.Results.Exceptions;
using System;
using System.Linq;
using System.Reflection;

namespace Kanbersky.Ocelot.Core.Helpers.Pagination
{
    public static class PaginationService
    {
        public static Pagination<T> GetPagination<T>(IQueryable<T> query, int page, string orderBy, bool orderByDesc, int pageSize) where T : class
        {
            Pagination<T> pagination = new Pagination<T>
            {
                TotalItems = query.Count(),
                PageSize = pageSize,
                CurrentPage = page,
                OrderBy = orderBy,
                OrderByDesc = orderByDesc,
            };

            int skip = (page - 1) * pageSize;
            var props = typeof(T).GetProperties();
            var orderByProperty = props.FirstOrDefault(n => n.GetCustomAttribute<SortableAttribute>()?.OrderBy == orderBy);

            pagination.TotalPages = pageSize != 0 ?  (pagination.TotalItems / pageSize) + 1 : 1;

            if (!string.IsNullOrEmpty(orderBy) && orderByProperty == null)
            {
                throw new NotFoundException($"Field: '{orderBy}' is not sortable");
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                if (orderByDesc)
                {
                    pagination.Result = query
                        .OrderByDescending(x => orderByProperty.GetValue(x))
                        .Skip(skip)
                        .Take(pageSize)
                        .ToList();

                    return pagination;
                }

                pagination.Result = query
                    .OrderBy(x => orderByProperty.GetValue(x))
                    .Skip(skip)
                    .Take(pageSize).ToList();

                return pagination;
            }
            else
            {
                pagination.Result = query
                       .Skip(skip)
                       .Take(pageSize)
                       .ToList();

                return pagination;
            }
        }
    }
}
