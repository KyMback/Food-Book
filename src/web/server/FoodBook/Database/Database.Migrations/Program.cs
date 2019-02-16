using System;
using System.IO;
using System.Linq;
using FoodBook.Database.Migrations.Enums;
using Microsoft.EntityFrameworkCore;

namespace FoodBook.Database.Migrations
{
    public class Program
    {
        public static int Main(string[] args)
        {
            switch (args.First())
            {
                case "update" : return UpdateDatabase(args);
                case "drop" : return DropDatabase(args);
                default: Console.WriteLine("Expected at least one parameter");
                    return (int)ApplicationReturnValue.Error;
            }
        }

        private static int UpdateDatabase(string[] args)
        {
            MigrationDbContext dbContext = new MigrationDbContextProvider().CreateDbContext(args);
            Console.WriteLine("Apply migrations...");
            dbContext.Database.Migrate();
            Console.WriteLine("Migrations was successfully applied");
            
            return (int) ApplicationReturnValue.Succeeded;
        }

        private static int DropDatabase(string[] args)
        {
            MigrationDbContext dbContext = new MigrationDbContextProvider().CreateDbContext(args);

            if (dbContext.Database.IsSqlite())
            {
                File.Delete(dbContext.Database.GetDbConnection().DataSource);
            }
            else
            {
                dbContext.Database.ExecuteSqlCommand("DROP DATABASE");
            }
            
            Console.WriteLine("Database was successfully dropped");
            return 0;
        }
    }
}