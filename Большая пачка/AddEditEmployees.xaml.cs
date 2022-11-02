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
        public AddEditEmployees(Сотрудники selectedsmena)
        {
            InitializeComponent();
            if(selectedsmena != null)
            {
                _currentAmployees = selectedsmena;
            }
            DataContext = _currentAmployees;
            //
            ComboWorkshop.ItemsSource = Большая_пачкаEntities.GetContext().Цех.ToList();
            ComboWorkshop.SelectedIndex = 0;
            //
            ComboMaritalStatus.ItemsSource = new List<string> { "Выбрать","Разведен","В браке","Вдовец"};
            ComboMaritalStatus.SelectedIndex = 0;
            //
            ComboHealth.ItemsSource = new List<string> { "Выбрать", "Здоров", "На больничном" };
            ComboHealth.SelectedIndex = 0;
            //
            ComboSpec.ItemsSource = new List<string> {"Выбрать","Сортировщик"};
            ComboSpec.SelectedIndex = 0;
            //
            ComboSmena.ItemsSource = new List<string> { "Выбрать", "Первая смена", "Вторая смена", "Третья смена" };
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
            if (DateBirthday.SelectedDate == null)
            {
                errors.AppendLine("Укажите дату рождения");
            }
            else _currentAmployees.Дата_рождения = DateBirthday.SelectedDate;
            //Серия и номер пасорта
            if (string.IsNullOrWhiteSpace(_currentAmployees.Серия_и_номер_паспорта))
            {
                errors.AppendLine("Укажите серию иномер паспорта");
            }
            //Кем выдан
            if (_currentAmployees == null)
            {
                errors.AppendLine("Укажите мастера");
            }
            //Место прописки
            if (string.IsNullOrWhiteSpace(_currentAmployees.Место_прописки))
            {
                errors.AppendLine("Укажите фактическое место прописки");
            }
            //Фактическое место жительство
            if (string.IsNullOrWhiteSpace(_currentAmployees.Фактическое_место_жительство))
            {
                errors.AppendLine("Укажите фактическое место жительства");
            }
            //Реквизиты
            if (string.IsNullOrWhiteSpace(_currentAmployees.Реквизиты))
            {
                errors.AppendLine("Укажите реквизиты");
            }
            //Семейное положение
            if (ComboMaritalStatus.SelectedIndex > 0)
            {
                _currentAmployees.Семейное_положение = ComboMaritalStatus.SelectedItem.ToString();
            }
            else errors.AppendLine("Укажите семейное положение");
            //Здоровье
            if (ComboHealth.SelectedIndex > 0)
            {
                _currentAmployees.Здоровье = ComboHealth.SelectedItem.ToString();
            }
            else errors.AppendLine("Укажите здоровье");
            //Специализация
            if (ComboSpec.SelectedIndex > 0)
            {
                _currentAmployees.Специализация = ComboSpec.SelectedItem.ToString();
            }
            else errors.AppendLine("Укажите специализацию");
            //Цех
            if (_currentAmployees.Цех == null)
            {
                errors.AppendLine("Укажите цех");
            }
            //Смена
            if(ComboSmena.SelectedIndex > 0)
            {
                _currentAmployees.ID_Смены = ComboSmena.SelectedIndex;
            }
            else errors.AppendLine("Укажите смену");
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentAmployees.ID_Сотрудника == 0)
            {
                Большая_пачкаEntities.GetContext().Сотрудники.Add(_currentAmployees);
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
