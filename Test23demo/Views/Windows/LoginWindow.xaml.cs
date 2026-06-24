using System.Linq;
using System.Windows;
using Test23demo.Model;

namespace Test23demo.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        int failedEntryCount = 0;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text) || string.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBox.Show("Заполните все поля", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                App.currentUsers = App.context.SystemUser.FirstOrDefault(u => u.Login == LoginTb.Text && u.Password == PasswordPb.Password);
                if (App.currentUsers != null)
                {
                    if (App.currentUsers.IsBlocked == false)
                    {
                        if (App.currentUsers.RoleId == 1)
                        {
                            MessageBox.Show("Вы успешно авторизовались", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            AdministratorWindow administratorWindow = new AdministratorWindow();
                            administratorWindow.Show();

                        }
                        else
                        {
                            MessageBox.Show("Вы успешно авторизовались", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            UsersWindow usersWindow = new UsersWindow();
                            usersWindow.Show();
                        }
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Вы заблокированы. Обратитесь к администратору", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    App.currentUsers = App.context.SystemUser.FirstOrDefault(u => u.Login == LoginTb.Text);

                    if (App.currentUsers != null)
                    {
                        failedEntryCount++;
                        MessageBox.Show($"Вы ввели неверный пароль осталось попыток {3 - failedEntryCount} из 3 ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        if (failedEntryCount == 3)
                        {
                            MessageBox.Show("Вы заблокированы. Обратитесь к администратору", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            failedEntryCount = 0;

                            SystemUser userToBlock = App.context.SystemUser.FirstOrDefault(s => s.Login == LoginTb.Text);
                            userToBlock.IsBlocked = true;
                            App.context.SaveChanges();
                        }

                    }
                    else
                    {
                        MessageBox.Show($"Вы ввели неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }



            }
        }
    }
}

