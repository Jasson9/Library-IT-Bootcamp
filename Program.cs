using Library;
using Library.Helper.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<LibraryDBContext>(
    options => options.UseMySql( connectionString, ServerVersion.AutoDetect(connectionString))
);
builder.Services.AddScoped<BookHelper>();
builder.Services.AddScoped<StudentHelper>();
builder.Services.AddScoped<StaffHelper>();
builder.Services.AddScoped<BorrowHelper>();

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
