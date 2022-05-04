using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Identity.Context
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<ApplicationIdentityDbContext>
    {
        public ApplicationIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration  = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("IdentityConnection");
            builder.UseMySql(connectionString, new MySqlServerVersion(new Version()));
            return new ApplicationIdentityDbContext(builder.Options);
        }
    }
}
