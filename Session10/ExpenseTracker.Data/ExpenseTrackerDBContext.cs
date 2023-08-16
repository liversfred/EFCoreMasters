﻿using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Data
{
    public class ExpenseTrackerDBContext : DbContext
    {
        //TODO: Setup DBContext for unit testing
        private DbContextOptions<ExpenseTrackerDBContext> _options;

        public ExpenseTrackerDBContext()
        {

        }

        public ExpenseTrackerDBContext(DbContextOptions<ExpenseTrackerDBContext> options) : base(options)
        {
            _options = options;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return builder.GetConnectionString("CustomTestDB");
        }
    }
}
