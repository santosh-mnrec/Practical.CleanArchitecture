﻿using ClassifiedAds.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Reflection;

namespace ClassifiedAds.Services.Storage.Repositories
{
    public class StorageDbContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _dbContextTransaction;

        public StorageDbContext(DbContextOptions<StorageDbContext> options)
            : base(options)
        {
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _dbContextTransaction = Database.BeginTransaction(isolationLevel);
        }

        public void CommitTransaction()
        {
            _dbContextTransaction.Commit();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
