using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ArchiveData.DbContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ArchiveContext>
    {
        public ArchiveContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(Environment.CurrentDirectory).ToString().ToString() + @"\ArchiveApi")
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<ArchiveContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ArchiveContext(builder.Options);
        }
    }
}
