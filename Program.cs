using CashFlowApi.Models;
using CashFlowApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EntryRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/entries", (EntryRepository repository) =>
{
    return repository.GetList();
})
.WithName("GetEntries");

app.MapGet("/api/entries/report", (EntryRepository repository) =>
{
    var list = repository.GetList();
    return new TodayEntriesReport(list);
})
.WithName("GetEntriesTodayReport");

app.Run();
