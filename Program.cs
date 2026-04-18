using Npgsql;
using store_front.Modules.Auth.Repositories;
using store_front.Modules.Auth.Services;
using store_front.Modules.Products.Repositories;
using store_front.Modules.Products.Services;

var builder = WebApplication.CreateBuilder(args);

// Registra servicos de framework e servicos de modulos.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173", "http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var lojinhaConnectionString = builder.Configuration.GetConnectionString("LojinhaDb")
    ?? throw new InvalidOperationException("Connection string 'LojinhaDb' nao encontrada.");
builder.Services.AddSingleton(new NpgsqlDataSourceBuilder(lojinhaConnectionString).Build());

// Fonte de dados atual em memoria para iteracao rapida.
builder.Services.AddScoped<IProductRepository, InMemoryProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("FrontendPolicy");

app.MapControllers();

app.Run();
