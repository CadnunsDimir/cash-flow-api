using CashFlowApi.Models;
using CashFlowApi.Repositories;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

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

//TODO: Add Model View on post and get
app.MapPost("/api/entries", async (Entry entry, EntryRepository repository) =>
{
    await repository.insert(entry);
    Results.Created($"/todoitems/{entry.Id}", entry);
});

app.MapGet("/api/entries/report", (EntryRepository repository) =>
{
    var list = repository.GetList();
    return new TodayEntriesReport(list);
});

 app.UseExceptionHandler(exceptionHandlerApp =>
 {
     exceptionHandlerApp.Run(async context =>
     {
         context.Response.StatusCode = StatusCodes.Status500InternalServerError;    
         await context.Response.WriteAsync("An exception was thrown.");
     });
 });

app.Run();
