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
    /// Логика взаимодействия для Start_Page.xaml
    /// </summary>
    public partial class Start_Page : Page
    {
        public Start_Page()
        {
            InitializeComponent();
        }

        private void Materials_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Materials());
        }

        private void WorkShifts_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new WorkShifts());
        }

        private void AddEditMats_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MaterialsForAddEditView());
        }
    }
}
