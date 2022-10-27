using CashFlowApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CashFlowApi.Repositories;
public class EntryRepository {
    private CashFlowDb db;

    public EntryRepository(CashFlowDb db){
        this.db = db;
    }

    private DbSet<Entry> Entries => db.Set<Entry>();

    public Task<int> insert(Entry entry) {
        this.Entries.Add(entry);
        return this.db.SaveChangesAsync();
    }
    public List<Entry> GetList() {
        return this.Entries.ToList();
    }

    internal TodayEntriesReport GenerateTodayEntriesReport()
    {
        var today = DateTime.Today;
        var tomorrow = today.AddDays(1);
        var todayEntries = this.Entries.Where(x=> x.Date >= today && x.Date < tomorrow).OrderBy(x=> x.Date).ToList();
        var todayInitialBalance = this.Entries.Where(x=> x.Date < today).Sum(x=>x.Value);
        var todayCurrentBalance = todayInitialBalance + todayEntries.Sum(x=>x.Value);
        return new TodayEntriesReport(todayInitialBalance, todayCurrentBalance, EntryViewModel.MapList(todayEntries));
    }
}