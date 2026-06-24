using System.Linq;
using System.Windows;
using Test23demo.Model;

namespace Test23demo.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUsersWindow.xaml
    /// </summary>
    public partial class AddUsersWindow : Window
    {
        public AddUsersWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text;
            if (App.context.SystemUser.Any(x => x.Login == login))
            {
                MessageBox.Show("Пользователь с таким логином уже есть", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SystemUser systemUser = new SystemUser()
            {
                Login = LoginTb.Text,
                Password = PasswordPb.Password,
                IsBlocked = false,
                CustomerId = 1,
                RoleId = 2
            };
            App.context.SystemUser.Add(systemUser);
            App.context.SaveChanges();
            MessageBox.Show("Пользователь успешно добавлен", "информация", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;

        }
    }
}
