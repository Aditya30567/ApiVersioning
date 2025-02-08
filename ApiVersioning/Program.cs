using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.ReportApiVersions = true;
    setupAction.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new QueryStringApiVersionReader("v"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("X-Version")
        );
}).AddMvc(options => { }).AddApiExplorer(options =>
{
    options.GroupNameFormat = "v'vvv'";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();






app.Run();
