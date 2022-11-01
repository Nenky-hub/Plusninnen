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
    /// Логика взаимодействия для AddEditEmployees.xaml
    /// </summary>
    public partial class AddEditEmployees : Page
    {
        private Сотрудники _currentAmployees = new Сотрудники();
        public AddEditEmployees()
        {
            InitializeComponent();
            //
            ComboMaritalStatus.ItemsSource = new List<string> {"Разведен","В браке","Вдовец"};
            ComboMaritalStatus.SelectedIndex = 0;
            //
            ComboHealth.ItemsSource = new List<string> { "Здоров", "На больничном" };
            ComboHealth.SelectedIndex = 0;
            //
            ComboSpec.ItemsSource = new List<string> {"Сортировщик"};
            ComboSpec.SelectedIndex = 0;
            //
            ComboSmena.ItemsSource = new List<string> {"Первая смена","Вторая смена","Третья смена"};
            ComboSmena.SelectedIndex = 0;
            //
        }

        private void ButtonSave_click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //проверка заполнения полей на допустимые значения
            //ФИО
            if (string.IsNullOrWhiteSpace(_currentAmployees.Фамилия))
            {
                errors.AppendLine("Укажите фамилию");
            }
            if (string.IsNullOrWhiteSpace(_currentAmployees.Имя))
            {
                errors.AppendLine("Укажите имя");
            }
            if (string.IsNullOrWhiteSpace(_currentAmployees.Отчество))
            {
                errors.AppendLine("Укажите отчество");
            }
            //Дата рождения
            if (_currentAmployees == null)
            {
                errors.AppendLine("Укажите время начала смены");
            }
            //Серия и номер пасорта
            if (_currentAmployees == null)
            {
                errors.AppendLine("Укажите время конца смены");
            }
            //Кем выдан
            if (_currentAmployees == null)
            {
                errors.AppendLine("Укажите мастера");
            }
            //Место прописки

            //Фактическое место жительство

            //Реквизиты

            //Семейное положение

            //Здоровье
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentWorkShifts.ID_Смены == 0)
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
