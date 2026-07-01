using BankPOS.Data;
using BankPOS.Interfaces;
using BankPOS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<BankPosDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
  {
      options.DocumentPath = "/openapi/v1.json";
  });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
