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
    /// Логика взаимодействия для AddEditMaterials.xaml
    /// </summary>
    public partial class AddEditMaterials : Page
    {
        private Материалы _currentMaterials = new Материалы();
        public AddEditMaterials( Материалы selectedMaterial)
        {
            InitializeComponent();
            if( selectedMaterial != null )
            {
                _currentMaterials = selectedMaterial;
            }
            DataContext = _currentMaterials;

            Combobox_NameMat.ItemsSource = new List<string> { "Выбрать", "Гранулы белый 2x2", "Нить серый 1x0", "Краска синий 2x2" };  /*Большая_пачкаEntities.GetContext().Материалы.ToList();*/

            Combobox_TypeMat.ItemsSource = new List<string> { "Выбрать", "Гранулы", "Нитки", "Краски" };
            Combobox_TypeMat.SelectedIndex = 0;

            Combobox_Unit.ItemsSource = new List<string> { "Выбрать", "кг","л","м"};
            Combobox_Unit.SelectedIndex = 0;

            //Combobox_Supp.ItemsSource = Большая_пачкаEntities.GetContext().Материалы.ToList();
            //Combobox_Supp.SelectedIndex = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //Наименование материала
            if (Combobox_NameMat.SelectedIndex == 0)
            {
                errors.AppendLine("Укажите наименование материала");
            }
            else _currentMaterials.Наименование_материала = Combobox_NameMat.SelectedItem.ToString();

            //Тип материала
            if (Combobox_TypeMat.SelectedIndex > 0)
            {
                _currentMaterials.Тип_материала = Combobox_TypeMat.SelectedItem.ToString();
            }

            //Цена
            if (_currentMaterials.Цена <= 0)
            {
                errors.AppendLine("Укажите цену");
            }
            //Количество на складе
            if (_currentMaterials.Количество_на_складе < 0)
            {
                errors.AppendLine("Укажите количество на складе");
            }
            //Минимальное количество
            if (_currentMaterials.Минимальное_количество <= 0)
            {
                errors.AppendLine("Укажите минимальное количество");
            }
            //Количество_в_упаковке
            if (_currentMaterials.Количество_в_упаковке <=0)
            {
                errors.AppendLine("Укажите количество в упаковке");
            }
            //Единица измерения
            if (Combobox_Unit.SelectedIndex == 0)
            {
                errors.AppendLine("Укажите ед. измерения");
            }
           else  _currentMaterials.Единица_измерения = Combobox_Unit.SelectedItem.ToString();

            ////Поставщик
            //if (_currentMaterials.Поставщик == null)
            //{
            //    errors.AppendLine("Укажите поставщика");
            //}

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMaterials.C_ID_Материалов == 0)
            {
                Большая_пачкаEntities.GetContext().Материалы.Add(_currentMaterials);
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
