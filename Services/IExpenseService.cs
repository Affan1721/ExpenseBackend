using SpendSmart.Models;

namespace SpendSmart.Services
{
    public interface IExpenseService
    {
        Expense GetExpenseById(int id);
        IEnumerable<Expense> GetAllExpenses();
        void CreateExpense(Expense expense);
        void UpdateExpense(Expense expense);
        void DeleteExpense(int id);
    }
}
