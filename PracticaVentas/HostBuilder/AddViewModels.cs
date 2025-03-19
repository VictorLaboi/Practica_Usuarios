using Kanban.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.HostBuilder
{
    public static class AddViewModels
    {
        public static IHostBuilder AddView(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<KanbanMainViewModel>();
            });
            return hostBuilder;
        }

    }
}
