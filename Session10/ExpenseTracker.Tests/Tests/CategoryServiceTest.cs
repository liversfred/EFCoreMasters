using ExpenseTracker.Data;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Services;
using ExpenseTracker.Tests.Helper;
using FluentAssertions;

namespace ExpenseTracker.Tests.Tests
{
    public class CategoryServiceTest
    {
        //TODO
        //Fill in the steps for every test
        //1. Create a unique dbcontextoption 
        //2. Setup a new database with fresh data for every test
        //3. Test respective method in the CategoryService.cs 
        //4. Do atleast 1 assertion using fluent assertions

        //GOAL: This test should run in parallel with ExpenseServiceTest

        private readonly string _className;
        public CategoryServiceTest()
        {
            _className = GetType().Name;
        }

        [Fact]
        public void GetAllCategories_ShouldReturnAllCategories()
        {
            //Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var service = new CategoryService(context);
            var expected = ExpenseTrackerTestData.ExpenseData().Select(x => x.Category).ToList();

            //Act
            var categories = service.GetAll();

            //Assert
            categories.Should().NotBeNull();
            categories.Should().HaveCount(expected.Count);
        }


        [Fact]
        public void GetSingleCategory_ShouldReturnRequested()
        {
            //Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            int categoryId = 2;

            var service = new CategoryService(context);
            var expected = ExpenseTrackerTestData.ExpenseData().Last();

            //Act
            var category = service.GetSingle(categoryId);

            //Assert
            category.Should().NotBeNull();
            category.Name.Should().BeEquivalentTo(expected.Category.Name);
            category.Description.Should().BeEquivalentTo(expected.Category.Description);
        }

        [Fact]
        public void AddCategory_ShouldSuccessfullyAddCategory()
        {
            //Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            int categoryId = 3;
            var newCategory = new Category
            {
                Name = $"Category{categoryId}",
                Description = $"Category{categoryId}",
            };

            var service = new CategoryService(context);

            //Act
            var category = service.Add(newCategory);
            context.ChangeTracker.Clear();

            //Assert
            category.Should().NotBeNull();
            category.CategoryId.Should().Be(categoryId);
            category.Name.Should().BeEquivalentTo(newCategory.Name);
            category.Description.Should().BeEquivalentTo(newCategory.Description);
        }

        [Fact]
        public void DeleteCategory_ShouldSuccessfullyDeleteCategory()
        {
            //Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var categoryToBeDeleted = new Category() { CategoryId = 2 };

            var service = new CategoryService(context);

            //Act
            service.Delete(categoryToBeDeleted);

            //Assert
            var deletedCategory = context.Categories.SingleOrDefault(x => x.CategoryId == categoryToBeDeleted.CategoryId);
            deletedCategory.Should().BeNull();
        }
    }
}
