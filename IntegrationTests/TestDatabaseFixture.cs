using Dukkantek.Db;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dukkantek.IntegrationTests
{
    public class TestDatabaseFixture : IDisposable
    {
        private const string ConnectionString = @"Server=localhost,1433; Database=Dukkantek; User=sa; Password=Password_123;";

        public TestDatabaseFixture()
        {
            DbContext = CreateDbContext();
        }

        public DukkantekDbContext DbContext {get; init; }

        public void Dispose()
        {
            // delete database,
            // so it will be recreated and we will get a fresh copy
            // when we run the app
            DbContext.Database.EnsureDeleted();

            DbContext?.Dispose();
        }

        private DukkantekDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DukkantekDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            return new DukkantekDbContext(optionsBuilder.Options);
        }
    }
}
