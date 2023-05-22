using ExpenseAndBorrowTracker.Models;
using InAndOut.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAndBorrowTracker.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Item> Item { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

    }
}
