using ExpenseTracker.Data;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Services;
using ExpenseTracker.Tests.Helper;
using FluentAssertions;

namespace ExpenseTracker.Tests.Tests
{
    public class ExpenseServiceTest
    {

        //TODO
        //Fill in the steps for every test
        //1. Create a unique dbcontextoption 
        //2. Setup a new database with fresh data for every test
        //3. Test respective method in the ExpenseService.cs 
        //4. Do atleast 1 assertion using fluent assertions

        //GOAL: This test should run in parallel with CategoryServiceTest

        private readonly string _className;
        public ExpenseServiceTest()
        {
            _className = GetType().Name;
        }

        [Fact]
        public void GetAllExpenses_ShouldReturnAllExpenses()
        {
            //Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new ExpenseService(context);
            var expected = ExpenseTrackerTestData.ExpenseData();

            //Act
            var expenses = service.GetAll();

            //Assert
            expenses.Should().NotBeNull();
            expenses.Should().HaveCount(expected.Count());
        }

        [Fact]
        public void GetAllOrderedByAmount_ExpensesShouldBeInAscendingOrder()
        {
            //Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new ExpenseService(context);
            var expected = ExpenseTrackerTestData.ExpenseData().OrderBy(x => x.ItemAmount).First();

            //Act
            var expenses = service.GetAllOrderedByAmount();

            //Assert
            expenses.Should().NotBeNull();
            var firstElementCategory = context.Categories.SingleOrDefault(x => x.CategoryId == expenses.First().CategoryId);
            firstElementCategory.Name.Should().BeEquivalentTo(expected.Category.Name);
            firstElementCategory.Description.Should().BeEquivalentTo(expected.Category.Description);
        }

        [Fact]
        public void GetSingleExpense_ShouldReturnRequested()
        {
            //Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            int expenseId = 2;

            var service = new ExpenseService(context);
            var expected = ExpenseTrackerTestData.ExpenseData().Last();

            //Act
            var expense = service.GetSingle(expenseId);

            //Assert
            expense.Should().NotBeNull();
            expense.Item.Should().BeEquivalentTo(expected.Item);
        }

        [Fact]
        public void AddExpense_ShouldSuccessfullyAddExpense()
        {
            //Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var expenseId = 3;
            var newExpense = new Expense
            {
                Item = $"Item{expenseId}",
                DatePurchased = DateTime.Now,
                ItemAmount = 300,
                Category = new Category()
                {
                    Name = $"Category{expenseId}",
                    Description = $"Category{expenseId}"
                }
            };

            var service = new ExpenseService(context);

            //Act
            var expense = service.Add(newExpense);
            context.ChangeTracker.Clear();

            //Assert
            expense.Should().NotBeNull();
            expense.Item.Should().BeEquivalentTo(newExpense.Item);
            expense.Category.Name.Should().BeEquivalentTo(newExpense.Category.Name);
        }

        [Fact]
        public void DeleteExpense_ShouldSuccessfullyDeleteExpense()
        {
            //Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var expenseToBeDeleted = new Expense() { ExpenseId = 2 };

            var service = new ExpenseService(context);

            //Act
            service.Delete(expenseToBeDeleted);

            //Assert
            var deletedExpense = context.Expenses.SingleOrDefault(x => x.ExpenseId == expenseToBeDeleted.ExpenseId);
            deletedExpense.Should().BeNull();
        }
    }
}
