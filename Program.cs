using web_api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDBContext>();
builder.Services.AddGraphQLServer()
.AddQueryType<CategoryQuery>()
.AddMutationType<CategoryMutation>()
.AddProjections()
.AddSorting()
.AddFiltering();

var app = builder.Build();
app.MapGraphQL();

app.Run();
