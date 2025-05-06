using SpendSmart.Models;

namespace SpendSmart.Repositories
{
    public interface IExpenseRepository
    {
        Expense GetById(int id);
        IEnumerable<Expense> GetAll();
        void Create(Expense expense);
        void Update(Expense expense);
        void Delete(int id);
    }
}
