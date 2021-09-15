﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marten;
using UpBlazor.Core.Models;
using UpBlazor.Core.Repositories;

namespace UpBlazor.Infrastructure.Repositories
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(IDocumentStore store) : base(store) { }

        public async Task<Expense> GetByIdAsync(Guid id) => 
            await Queryable
                .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IReadOnlyList<Expense>> GetAllByUserIdAsync(string userId) =>
            await Queryable
                .Where(x => x.UserId == userId)
                .ToListAsync();
    }
}