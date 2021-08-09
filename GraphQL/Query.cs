using System.Linq;
using graphql_todolist.Data;
using graphql_todolist.Models;
using HotChocolate;
using HotChocolate.Data;

namespace graphql_todolist.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetList([ScopedService] ApiDbContext context)
        {
            return context.Lists;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData> GetDatas([ScopedService] ApiDbContext context)
        {
            return context.Items;
        }
    }

}