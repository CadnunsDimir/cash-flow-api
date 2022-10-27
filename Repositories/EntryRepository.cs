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
    public Entry[] GetList() {
        return this.Entries.ToArray();
    }
}