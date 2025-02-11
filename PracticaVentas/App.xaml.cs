using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PracticaVentas.Commands;
using PracticaVentas.HostBuilder;
using PracticaVentas.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PracticaVentas
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public IHost AppHost { get; set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder().AddView().ConfigureServices((hostContex, services) => {

                string connectionString = hostContex.Configuration.GetConnectionString("ConnectionString")!;
                if (connectionString != null) {
                    services.AddSingleton<IConnectBD>(sp => new BDConnection(connectionString));
                }
                else
                {
                  throw new InvalidOperationException($"Connection string cannot be null.");
                }

                services.AddSingleton<INavigationServices, NavigationCommand>();
                
                //Registro de Func<Type,VM> para obtener el tipo y utilizarlo en el navigation services. 
                services.AddSingleton<Func<Type, ViewModel>>(s  =>  viewModelType => (ViewModel)s.GetRequiredService(viewModelType));

                services.AddSingleton<CrudOperationsData>();

                    services.AddSingleton(s => new MainWindow
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
            }).Build();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            AppHost.Start();
            MainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
        
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            AppHost.Dispose();
            base.OnExit(e);

        }
    }

}
