using System.Windows;
using Test23demo.Model;

namespace Test23demo.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditUsersWindow.xaml
    /// </summary>
    public partial class EditUsersWindow : Window
    {
        SystemUser systemUser;
        public EditUsersWindow(SystemUser systemUser)
        {
            InitializeComponent();
            this.systemUser = systemUser;
            DataContext = systemUser;
            CheckCb.IsChecked = systemUser.IsBlocked;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            systemUser.IsBlocked = CheckCb.IsChecked ?? false;

            App.context.SaveChanges();
            MessageBox.Show("Данные отредактированы", "информация", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
        }
    }
}
