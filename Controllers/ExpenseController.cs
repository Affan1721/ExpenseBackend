using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;
using SpendSmart.Services;


namespace SpendSmart.Controllers;

[ApiController]
[Route("api/expenses")]
[Produces("application/json")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpGet("List")] 
    public ActionResult<IEnumerable<Expense>> GetExpenses()
    {
        IEnumerable<Expense> expenses = _expenseService.GetAllExpenses();
        return Ok(expenses.ToList());
    }

 
    

    [HttpPost("Create")]
    public ActionResult<Expense> CreateExpense([FromBody] Expense expense)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _expenseService.CreateExpense(expense);
        return CreatedAtAction(nameof(GetExpenseById), new { id = expense.Id }, expense);
    }
    public ActionResult<Expense> GetExpenseById(int id)
    {
        var expense = _expenseService.GetExpenseById(id);
        if (expense == null)
        {
            return NotFound();
        }
        return Ok(expense);
    }

    [HttpPut("Update/{id}")]
    public IActionResult UpdateExpense(int id, [FromBody] Expense expense)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingExpense = _expenseService.GetExpenseById(id);
        if (existingExpense == null)
        {
            return NotFound();
        }

        existingExpense.Value = expense.Value;
        existingExpense.Description = expense.Description;
 
        _expenseService.UpdateExpense(existingExpense);
        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult DeleteExpense(int id)
    {
        var expenseToDelete = _expenseService.GetExpenseById(id);
        if (expenseToDelete == null)
        {
            return NotFound();
        }

        _expenseService.DeleteExpense(id);
        return NoContent();
    }
}