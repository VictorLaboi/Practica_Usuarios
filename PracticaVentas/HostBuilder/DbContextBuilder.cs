using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.HostBuilder
{
    class DbContextBuilder
    {
        public static IHostBuilder AddDbContextBuilder(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) => {

                string connectionString = context.Configuration.GetConnectionString("ConnectionString");
                if (connectionString != null) {
                    Action<DbContextOptionsBuilder> configureDbBuilder = o=> o.UseSqlServer(connectionString);
                }
            
            }); 
        }
    }
}
