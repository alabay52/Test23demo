using System.Linq;
using System.Windows;
using Test23demo.Model;

namespace Test23demo.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            UsersLv.ItemsSource = App.context.SystemUser.ToList();
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            SystemUser systemUser = UsersLv.SelectedItem as SystemUser;
            if (systemUser != null)
            {


                EditUsersWindow eitUsersWindow = new EditUsersWindow(systemUser);
                if (eitUsersWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("выберите полль");
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUsersWindow addUsersWindow = new AddUsersWindow();
            if (addUsersWindow.ShowDialog() == true)
            {
                LoadData();
            }
        }
    }
}
