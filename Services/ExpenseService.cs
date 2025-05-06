using SpendSmart.Models;
using SpendSmart.Repositories;

namespace SpendSmart.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public Expense GetExpenseById(int id)
        {
            return _expenseRepository.GetById(id);
        }
        public IEnumerable<Expense> GetAllExpenses()
        {
            return _expenseRepository.GetAll();
        }
        public void CreateExpense(Expense expense)
        {
            _expenseRepository.Create(expense);
        }
        public void UpdateExpense(Expense expense)
        {
            _expenseRepository.Update(expense);
        }
        public void DeleteExpense(int id)
        {
            _expenseRepository.Delete(id);
        }
    }
}
