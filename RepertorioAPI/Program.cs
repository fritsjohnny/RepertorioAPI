using Microsoft.EntityFrameworkCore;
using RepertorioAPI.Data;
using RepertorioAPI.Services;


var builder = WebApplication.CreateBuilder(args);

int mode = 0;

//if (Debugger.IsAttached)
//{
//	mode = 1;
//}

if (mode == 0)
{
    builder.Services.AddDbContext<RepertorioContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection")));
}
else
{
    builder.Services.AddDbContext<RepertorioContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));
}

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "RepertorioAPI",
        Version = "v1"
    });
});

builder.Services.AddCors();

// Add services to the container.
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<IRepertoireService, RepertoireService>();
builder.Services.AddScoped<IRepertoireSongService, RepertoireSongService>();
builder.Services.AddScoped<IUserService, UserService>();

// Authentication and Authorization
//builder.Services.AddScoped<IJwtUtils, JwtUtils>();


builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
