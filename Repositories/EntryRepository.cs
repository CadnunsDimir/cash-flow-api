using CashFlowApi.Models;

namespace CashFlowApi.Repositories;
public class EntryRepository {
    public Entry[] GetList() {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };        

        var yesterdayEntries =  Enumerable.Range(1, 5).Select(index =>
        new Entry
        (
            index,
            DateTime.Now.AddDays(-1),
            summaries[Random.Shared.Next(summaries.Length)],
            3.42m * index
        ))
        .ToArray();

        var todayEntries = Enumerable.Range(6, 9).Select(index =>
        new Entry
        (
            index,
            DateTime.Today.AddHours(index),
            summaries[Random.Shared.Next(summaries.Length)],
            3.42m * index
        ))
        .ToArray();

        return yesterdayEntries.Concat(todayEntries).ToArray();
    }
}