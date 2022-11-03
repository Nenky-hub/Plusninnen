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
    /// Логика взаимодействия для MaterialsForAddEditView.xaml
    /// </summary>
    public partial class MaterialsForAddEditView : Page
    {
        public MaterialsForAddEditView()
        {
            InitializeComponent();

        }

        private void ButtonEdit_Ckick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditMaterials((sender as Button).DataContext as Материалы));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Большая_пачкаEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataGridMaterials.ItemsSource = Большая_пачкаEntities.GetContext().Материалы.ToList();
            }
        }

        private void AddMaterials_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditMaterials(null));
        }
    }
}
