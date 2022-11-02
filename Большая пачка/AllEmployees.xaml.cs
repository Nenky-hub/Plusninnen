using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Большая_пачка
{
    /// <summary>
    /// Логика взаимодействия для AllEmployees.xaml
    /// </summary>
    public partial class AllEmployees : Page
    {
        //private Сотрудники _currentEmployees = new Сотрудники();
        public AllEmployees()
        {
            InitializeComponent();
            DataGridEmployees.ItemsSource = Большая_пачкаEntities.GetContext().Сотрудники.ToList();
            //// var _currentEmployees = Большая_пачкаEntities.GetContext().Сотрудники.ToList();
            //_currentEmployees.Дата_рождения = DateTime.Parse(string.Format("{0:dd-mm-yyyy}", _currentEmployees.Дата_рождения));
        }

        private void BtnAddEmployess_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditEmployees(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Большая_пачкаEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataGridEmployees.ItemsSource = Большая_пачкаEntities.GetContext().Сотрудники.ToList();
            }
        }

        private void ButtonEdit_Ckick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditEmployees((sender as Button).DataContext as Сотрудники));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var EmployeesForRemoving = DataGridEmployees.SelectedItems.Cast<Сотрудники>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {EmployeesForRemoving.Count()} элементов","Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Большая_пачкаEntities.GetContext().Сотрудники.RemoveRange(EmployeesForRemoving);
                    Большая_пачкаEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DataGridEmployees.ItemsSource = Большая_пачкаEntities.GetContext().Сотрудники.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
