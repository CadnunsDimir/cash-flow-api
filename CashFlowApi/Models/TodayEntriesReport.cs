namespace CashFlowApi.Models;
public record TodayEntriesReport(decimal TodayInitialBalance, decimal TodayCurrentBalance, List<EntryViewModel> TodayEntries);