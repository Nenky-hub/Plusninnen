using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;

namespace Большая_пачка
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public string Access;
        public Autorization()
        {
            InitializeComponent();
        }
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Username_Box.Text))
            {
                errors.AppendLine("Укажите логин");
            }

            if (string.IsNullOrWhiteSpace(Password_Box.Text))
            {
                errors.AppendLine("Укажите пароль");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка входа.");
                return;
            }


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"SELECT Access FROM Пользователь where Логин ='{Username_Box.Text}' and Пароль = '{GetHash(Password_Box.Text)}'";
       
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = dbs.mssql.app.biik.ru; Initial Catalog=Большая пачка; Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand(querystring, sqlConnection);

            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                // MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Access = table.Rows[0][0].ToString();
                if (Access == "agent")
                {
                    Manager.MainFrame.Navigate(new MaterialsForAddEditView());
                    sqlConnection.Close();
                }
                else if (Access == "admin")
                {
                    Manager.MainFrame.Navigate(new Start_Page());
                    sqlConnection.Close();
                }
                else if (Access == "master")
                {
                    Manager.MainFrame.Navigate(new WorkShifts());
                    sqlConnection.Close();
                }
            }
            else
                MessageBox.Show("Логин или пароль неверный. Если Вы забыли пароль - обратитесь к администратору", "Аккаунт не обнаружен!", MessageBoxButton.OK);

        }
    }
}
