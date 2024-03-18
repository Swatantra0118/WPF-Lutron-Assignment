using Caliburn.Micro;
using LutronOrderingSystem.DataAccess;
using LutronOrderingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LutronOrderingSystem
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            InitializeDatabase();
            DisplayRootViewForAsync<ProductsViewModel>();
        }
        private void InitializeDatabase()
        {
            DatabaseInitializer initializer = new DatabaseInitializer();
            initializer.CreateDatabaseAndTables();
            //initializer.SeedInitialValues();
        }
    }
}
