using HotChocolate;
using HotChocolate.AspNetCore;

namespace web_api
{
    public class CategoryInput
    {
        public required string Name { get; set; }
    }

    public class CategoryMutation
    {
        [GraphQLName("createCategory")]
        public Task<Category> CreateCategory([Service] AppDBContext context, CategoryInput input)
        {
            try
            {
                var category = new Category
                {
                    Name = input.Name
                };
                context.Categories.Add(category);
                context.SaveChanges();
                return Task.FromResult(category);
            }
            catch (Exception ex)
            {

                throw new GraphQLRequestException(new ErrorBuilder()
                    .SetMessage(ex.Message)
                    .Build());
            }
        }
    }
}