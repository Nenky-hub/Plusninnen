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
    /// Логика взаимодействия для AddEditWorkShifts.xaml
    /// </summary>
    public partial class AddEditWorkShifts : Page
    {
        private Смена _currentWorkShifts = new Смена();
        public AddEditWorkShifts( Смена selectedWorkShifts)
        {
            InitializeComponent();

            if (selectedWorkShifts != null)
            {
                _currentWorkShifts = selectedWorkShifts;
            }


            DataContext = _currentWorkShifts;
            ComboboxMaster.ItemsSource = Большая_пачкаEntities.GetContext().Мастер_производства.ToList();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            //if (_currentWorkShifts.ID_Смены <= 0 || _currentWorkShifts.ID_Смены > 3)
            //{
            //    errors.AppendLine("Укажите номер смены 1-3");
            //}

            if (_currentWorkShifts.Время_начала_смены == null)
            {
                errors.AppendLine("Укажите время начала смены");
            }
            if (_currentWorkShifts.Время_конца_смены == null)
            {
                errors.AppendLine("Укажите время конца смены");
            }
            if (_currentWorkShifts.Мастер_производства ==null)
            {
                errors.AppendLine("Укажите мастера");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_currentWorkShifts.ID_Смены == 0)
            {
                Большая_пачкаEntities.GetContext().Смена.Add(_currentWorkShifts);
            }
            try
            {
               Большая_пачкаEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
