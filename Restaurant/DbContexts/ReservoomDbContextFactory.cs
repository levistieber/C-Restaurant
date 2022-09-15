using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DbContexts
{
    public class RestaurantDbContextFactory
    {
        private readonly string _connectionString;

        public RestaurantDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public RestaurantDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new RestaurantDbContext(options);
        }
    }
}
