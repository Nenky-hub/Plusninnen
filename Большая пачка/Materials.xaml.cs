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
    /// Логика взаимодействия для Materials.xaml
    /// </summary>
    public partial class Materials : Page
    {
        public Materials()
        {
            InitializeComponent();

            //var _currentMaterials = Большая_пачкаEntities.GetContext().Материалы.ToList();
            //LViewMaterials.ItemsSource = _currentMaterials;

            var allMaterials = Большая_пачкаEntities.GetContext().Материалы.ToList();
            allMaterials.Insert(0, new Материалы
            {
                Наименование_материала = "Все типы"
            });
            ComboboxFilter.ItemsSource = allMaterials;
            ComboboxFilter.SelectedIndex = 0;
            UpdateMaterials();
        }
        private void UpdateMaterials()
        {
            var _currentMaterials = Большая_пачкаEntities.GetContext().Материалы.ToList();


            if (ComboboxFilter.SelectedIndex > 0)
            {
                _currentMaterials = _currentMaterials.Where(p => p.Тип_материала.Contains(ComboboxFilter.SelectedItem as Материалы)).ToList();
            }

            _currentMaterials = _currentMaterials.Where(p => p.Наименование_материала.ToLower().Contains(TBoxSerch.Text.ToLower())).ToList();

            //if (CheckActual.IsChecked.Value)
            //{
            //    _currentMaterials = _currentMaterials.Where(p => (bool)p.IsActual).ToList();
            //}

            LViewMaterials.ItemsSource = _currentMaterials.OrderBy(p => p.Количество_на_складе).ToList();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

      
        private void ComboBoxFilte_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
