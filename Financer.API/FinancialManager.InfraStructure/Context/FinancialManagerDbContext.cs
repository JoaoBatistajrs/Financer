﻿using FinancialManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.InfraStructure.Context
{
    public class FinancialManagerDbContext : DbContext
    {
        public FinancialManagerDbContext(DbContextOptions<FinancialManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<RegisterType> RegisterTypes { get; set; }
    }
}
