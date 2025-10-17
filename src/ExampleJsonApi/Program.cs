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
builder.Services.AddOpenApiForJsonApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseRouting();
app.UseJsonApi();

// Prevent caching of swagger JSON in development to avoid stale discriminator/type info.
app.Use(async (ctx, next) =>
{
  if (ctx.Request.Path.StartsWithSegments("/swagger"))
  {
    ctx.Response.Headers.CacheControl = "no-store, no-cache, must-revalidate";
    ctx.Response.Headers.Pragma = "no-cache";
    ctx.Response.Headers.Expires = "0";
  }
  await next();
});
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
