using ContactDataAccessLayer;
using ContactServiceLayer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net;
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
app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "text/html";
        var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
        if (exceptionObject != null)
        {
            var errorMessage = $"********** Handling error in global exception handler  ************ <b>Exception Error: {exceptionObject.Error.Message}</b> {exceptionObject.Error.StackTrace}";
            await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
        }
    });
});
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

