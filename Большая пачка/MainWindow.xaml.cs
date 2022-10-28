using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace Большая_пачка
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Start_Page());
            Manager.MainFrame = MainFrame;

            //ImportMaterials();
            //ImportSupplier();
        }
        private void ImportMaterials()
        {

            var fileData = File.ReadAllLines(@"\\FSProfile1.biik.ad.biik.ru\Redirect\plusnin\Desktop\Материалы.txt");
            var images = Directory.GetFiles(@"\\FSProfile1.biik.ad.biik.ru\Redirect\plusnin\Downloads\Пара 24.10.22\Задание 24.10.22\Вариант 1\Сессия 1\materials");

            foreach (var line in fileData)
            {
                var data = line.Split('\t');

                var tempMaterials = new Материалы
                {
                    Наименование_материала = data[0].Replace("\"", ""),
                    Тип_материала = data[1],

                    Цена = decimal.Parse(data[3]),
                    Количество_на_складе = int.Parse(data[4]),
                    Минимальное_количество = int.Parse(data[5]),
                    Количество_в_упаковке = int.Parse(data[6]),
                    Единица_измерения = data[7]
                };
                try
                {
                    tempMaterials.Изображение = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(data[2])));
                }
                catch
                {
                    
                }
                Большая_пачкаEntities.GetContext().Материалы.Add(tempMaterials);
                Большая_пачкаEntities.GetContext().SaveChanges();
            }
        }
        private void ImportSupplier()
        {
            var fileData = File.ReadAllLines(@"\\FSProfile1.biik.ad.biik.ru\Redirect\plusnin\Desktop\Поставщики.txt");


            foreach (var line in fileData)
            {
                var data = line.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                var tempSuppliers = new Поставщик
                {
                    Наименование = data[0].Replace("\"", ""),
                    Тип_поставщика = data[1],

                    ИНН = data[2],
                    Рейтинг = int.Parse(data[3].Replace("в рейтинге","" ).Replace("Рейтинг = ","")),
                    Дата_начала_работы_с_поставщиком = DateTime.Parse(string.Format("{0:dd-mm-yyyy}", data[4]))
                };
                
                Большая_пачкаEntities.GetContext().Поставщик.Add(tempSuppliers);
                Большая_пачкаEntities.GetContext().SaveChanges();
            }

        }

        private void MainFrame_CR(object sender, EventArgs e)
        {
            if(MainFrame.CanGoBack)
            {
                Back_Button.Visibility = Visibility.Visible;
            }
            else
            {
                Back_Button.Visibility = Visibility.Hidden;
            }
        }
       
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
