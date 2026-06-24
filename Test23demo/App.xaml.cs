using System.Windows;
using Test23demo.Model;

namespace Test23demo
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ManufacturerDb22Entities context = new ManufacturerDb22Entities();
        public static SystemUser currentUsers { get; set; }
    }
}
