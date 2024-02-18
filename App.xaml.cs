using System;
using PensiuneaMea.Data;
using System.IO;
namespace PensiuneaMea
{
    public partial class App : Application
    {
        static PensiuneaMeaDatabase database;
        public static PensiuneaMeaDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PensiuneaMeaDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PensiuneaMea.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
