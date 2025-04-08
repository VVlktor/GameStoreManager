using GameStoreManager.Client.Core;
using GameStoreManager.Client.Services;
using GameStoreManager.Client.ViewModels;
using GameStoreManager.Client.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace GameStoreManager.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            ServiceCollection services = new();

            services.AddSingleton<WindowManager>();
            services.AddTransient<MainView>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<AuctionManagerView>();
            services.AddTransient<AuctionManagerViewModel>();
            services.AddHttpClient<IGameOffersApiService, GameOffersApiService>(client => client.BaseAddress = new Uri("http://localhost:5207"));

            ServiceProvider = services.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainView>();
            mainWindow.Show();

        }
    }

}
