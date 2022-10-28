namespace CashFlowApi.Models;

public record Entry(int Id, DateTime Date, string Description, decimal Value) {}