namespace CashFlowApi.Models;
public class TodayEntriesReport{

    public decimal TodayInitialBalance { get; private set; }
    public List<Entry> TodayEntries { get; private set; }
    public decimal TodayCurrentBalance { get; private set; }
    public TodayEntriesReport(Entry[] entries) {
        var today = DateTime.Today;
        var tomorrow = today.AddDays(1);
        TodayEntries = entries.Where(x=> x.Date >= today && x.Date < tomorrow).OrderBy(x=> x.Date).ToList();
        TodayInitialBalance = entries.Where(x=> x.Date < today).Sum(x=>x.Value);
        TodayCurrentBalance = TodayInitialBalance + TodayEntries.Sum(x=>x.Value);
    }
}