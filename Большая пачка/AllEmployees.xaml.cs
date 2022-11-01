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
            Manager.MainFrame.Navigate(new AddEditEmployees());
        }
    }
}
