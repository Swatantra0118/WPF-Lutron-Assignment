using LutronOrderingSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LutronOrderingSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize database and seed initial values
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            DatabaseInitializer initializer = new DatabaseInitializer();
            initializer.CreateDatabaseAndTables();
            //initializer.SeedInitialValues();
        }
    }
}
