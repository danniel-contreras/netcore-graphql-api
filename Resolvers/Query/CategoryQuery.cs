using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Data;

namespace web_api
{
    public class CategoryQuery
    {
        [UseProjection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Category> GetCategories([Service] AppDBContext context)
        {
            return context.Categories;
        }

        public Category GetCategory([Service] AppDBContext context, int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id) ?? throw new GraphQLRequestException(ErrorBuilder.New().SetMessage("Category not found").Build());
            return category;
        }
    }
}