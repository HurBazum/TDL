using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using TDL.BLL;
using TDL.DAL;
using TDL.ViewModels.Tools;

namespace TDL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static IHost? _host;

        public static IHost Host => _host ?? Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        protected override void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);
            host.StartAsync().ConfigureAwait(false);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var host = Host;
            base.OnExit(e);

            host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _host = null;
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .Adddatabase()
            .AddRepositories()
            .AddServices()
            .AddViewModels();
    }

}