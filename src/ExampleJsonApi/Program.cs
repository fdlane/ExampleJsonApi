using ExampleJsonApi;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.OpenApi.Swashbuckle;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddJsonApi<AppDbContext>(options =>
{
  options.UseRelativeLinks = true;
  options.IncludeTotalResourceCount = true;
});
builder.Services.AddJsonApi<AppDbContext>();
builder.Services.AddOpenApiForJsonApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseRouting();
app.UseJsonApi();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
await CreateDatabaseAsync(app.Services);
app.Run();

static async Task CreateDatabaseAsync(IServiceProvider serviceProvider)
{
  await using var scope = serviceProvider.CreateAsyncScope();
  var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
  await dbContext.Database.EnsureDeletedAsync();
  await dbContext.Database.EnsureCreatedAsync();
}
