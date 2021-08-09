using System.Threading.Tasks;
using graphql_todolist.Data;
using graphql_todolist.GraphQL.DataItem;
using graphql_todolist.GraphQL.Lists;
using graphql_todolist.Models;
using HotChocolate;
using HotChocolate.Data;

namespace graphql_todolist.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddListPayload> AddListAsync(AddListInput input, [ScopedService] ApiDbContext context)
        {
            var list = new ItemList
            {
                Name = input.name
            };

            context.Lists.Add(list);
            await context.SaveChangesAsync();

            return new AddListPayload(list);
        }

        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddItemPayload> AddItemAsync(AddItemInput input, [ScopedService] ApiDbContext context)
        {
            var item = new ItemData
            {
                IsDone = input.isDone,
                Description = input.description,
                ListId = input.listId,
                Title = input.title
            };

            context.Items.Add(item);
            await context.SaveChangesAsync();

            return new AddItemPayload(item);
        }

    }
}