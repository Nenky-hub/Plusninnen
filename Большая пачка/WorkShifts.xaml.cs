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
    /// Логика взаимодействия для WorkShifts.xaml
    /// </summary>
    public partial class WorkShifts : Page
    {
        public WorkShifts()
        {
            InitializeComponent();
            DataGrid_WorkSgifts.ItemsSource = Большая_пачкаEntities.GetContext().Смена.ToList();
        }

        private void ButtonEdit_Ckick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditWorkShifts((sender as Button).DataContext as Смена));
        }

        private void ButtonAddWorkShifts_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditWorkShifts(null));
        }

        private void ButtonAllEmployees_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AllEmployees());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Большая_пачкаEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataGrid_WorkSgifts.ItemsSource = Большая_пачкаEntities.GetContext().Смена.ToList();
            }
        }

        
        
    }
}
