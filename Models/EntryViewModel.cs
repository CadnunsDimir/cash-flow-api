namespace CashFlowApi.Models;

public record EntryViewModel(DateTime? Date, string Description, decimal Value)
{
    public Entry toDbModel()
    {
        return new Entry(0, this.Date ?? DateTime.Now, this.Description, this.Value);
    }

    public static List<EntryViewModel> MapList(List<Entry> entries)
    {
        return entries.Select(x=> new EntryViewModel(x.Date, x.Description, x.Value)).ToList();
    }
}