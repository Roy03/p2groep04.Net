using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace p2groep04.Models.DAL
{
    public class CreateAndMigrateDatabaseInitializer<TContext, TConfiguration> : CreateDatabaseIfNotExists<TContext>, IDatabaseInitializer<TContext>
        where TContext : DbContext
        where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private readonly DbMigrationsConfiguration _configuration;
        public CreateAndMigrateDatabaseInitializer()
        {
            _configuration = new TConfiguration();
        }
        public CreateAndMigrateDatabaseInitializer(string connection)
        {
            Contract.Requires(!string.IsNullOrEmpty(connection), "connection");

            _configuration = new TConfiguration
            {
                TargetDatabase = new DbConnectionInfo(connection)
            };
        }
        void IDatabaseInitializer<TContext>.InitializeDatabase(TContext context)
        {
            Contract.Requires(context != null, "context");

            var migrator = new DbMigrator(_configuration);
            migrator.Update();

            // move on with the 'CreateDatabaseIfNotExists' for the 'Seed'
            base.InitializeDatabase(context);
        }
        protected override void Seed(TContext context)
        {
            var doseed = !context.Database.Exists();
            // && new DatabaseTableChecker().AnyModelTableExists(context);
            // check to see if to seed - we 'lack' the 'AnyModelTableExists' - could be copied/done otherwise if needed...

            var migrator = new DbMigrator(_configuration);
            // if (doseed || !context.Database.CompatibleWithModel(throwIfNoMetadata: false))
            if (migrator.GetPendingMigrations().Any())
                migrator.Update();

            // move on with the 'CreateDatabaseIfNotExists' for the 'Seed'
            base.InitializeDatabase(context);
            if (doseed)
            {
                Seed(context);
                context.SaveChanges();
            }
        }
    }
}