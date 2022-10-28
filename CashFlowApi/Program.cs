using CashFlowApi.Models;
using CashFlowApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EntryRepository>();
builder.Services.AddDbContext<CashFlowDb>(opt => opt.UseInMemoryDatabase("EntryList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();    
}

app.UseHttpsRedirection();

app.MapGet("/api/cash-flow", (EntryRepository repository) =>
{
    return EntryViewModel.MapList(repository.GetList());
});

app.MapPost("/api/cash-flow", async (EntryViewModel viewModel, EntryRepository repository) =>
{
    var entry = viewModel.toDbModel();
    await repository.insert(entry);
    Results.Created("/api/cash-flow/", viewModel);
});

app.MapGet("/api/cash-flow/report", (EntryRepository repository) =>
{    
    return repository.GenerateTodayEntriesReport();
});

 app.UseExceptionHandler(exceptionHandlerApp =>
 {
     exceptionHandlerApp.Run(async context =>
     {
         context.Response.StatusCode = StatusCodes.Status500InternalServerError;    
         await context.Response.WriteAsync("Internal Error");
     });
 });

app.Run();
