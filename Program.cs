using ContactDataAccessLayer;
using ContactServiceLayer;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<ContactManagementServiceContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactManagementServiceContext") ?? throw new InvalidOperationException("Connection string 'ContactManagementServiceContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IContactDetailsService, ContactDetailsDAL>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();

