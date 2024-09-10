using AuthenticationService.DAL;
using AuthenticationService.Middlewares;
using AuthenticationService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration["DefaultConnection"];
builder.Services.AddDbContext<AppDBContext>(options =>
{
    //options.LogTo();
    options.UseNpgsql(connectionString);
});

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<JwtMiddleware>();

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
