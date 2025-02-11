using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PracticaVentas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaVentas.HostBuilder
{
    public static class AddViewModels
    {
        public static IHostBuilder AddView(this IHostBuilder hostBuilder) {
            hostBuilder.ConfigureServices(services => {
                services.AddSingleton<Func<PersonViewModel>>((s) => () => s.GetRequiredService<PersonViewModel>());
                services.AddTransient<PersonViewModel>();
                services.AddSingleton<ManagmentViewModel>();
                services.AddSingleton<MainViewModel>();
            });
            return hostBuilder; 
        }

    }
}
