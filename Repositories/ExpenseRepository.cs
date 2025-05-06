using SpendSmart.Data;
using SpendSmart.Models;

namespace SpendSmart.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly SpendSmartDBContext _dbContext;

        public ExpenseRepository(SpendSmartDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Expense GetById(int id)
        {
            var expense = _dbContext.Expense.Find(id);
            return expense;
        }

        public IEnumerable<Expense> GetAll()
        {
            return (IEnumerable<Expense>)_dbContext.Expense.ToList();
        }

        public void Create(Expense expense)
        {
            _dbContext.Expense.Add(expense);
            _dbContext.SaveChanges();

        }

        public void Update(Expense expense)
        {

            _dbContext.Expense.Update(expense);
            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var expenseToDelete = _dbContext.Expense.Find(id);

            _dbContext.Expense.Remove(expenseToDelete);
            _dbContext.SaveChanges();

        }
    }
}
