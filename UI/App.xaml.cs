using DataLayer.Database;
using DataLayer.Logger;
using DataLayer.Service;
using System.Configuration;
using System.Data;
using System.Windows;
using UI.ViewModel;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (var ctx = new DatabaseContext())
                ctx.Database.EnsureCreated();
        }
    }

}
