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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace loginkosto4
{
    /// <summary>
    /// Логика взаимодействия для winZakaz.xaml
    /// </summary>
    public partial class winZakaz : Window
    {
        public winZakaz()
        {
            InitializeComponent();
            ListMebel.Visibility = Visibility.Hidden;
            ListClient.Visibility = Visibility.Hidden;

        }

        public class mebelS
        {
            public string codc { get; set; }
            public string name { get; set; }
            public string material { get; set; }
            public string dlina { get; set; }
            public string shirina { get; set; }
            public string visota { get; set; }
          
        }

        public class clientS
        {
            public string codc { get; set; }
            public string fio { get; set; }
            public string adress { get; set; }
            public string avans { get; set; }
            public string cost { get; set; }

        }
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=ZET-PC\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=Mebel;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;
        }

        

    private void btnAvans_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListMebel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnMebel_Click(object sender, RoutedEventArgs e)
        {
            ListClient.Items.Clear();
            ListClient.Visibility = Visibility.Hidden;
            ListMebel.Visibility = Visibility.Visible;
            LoadMebel();
        }

        void LoadMebel()
        {
            DataTable dt_mebel = Select("SELECT * FROM [dbo].[Table_mebel]");
            for (int i = 0; i < dt_mebel.Rows.Count; i++) // перебираем данные
            {
                mebelS dataUser = new mebelS() // создаём экземпляр класса
                {
                    codc = dt_mebel.Rows[i][0].ToString(),
                    name = dt_mebel.Rows[i][1].ToString(),
                    material = dt_mebel.Rows[i][2].ToString(),
                    dlina = dt_mebel.Rows[i][3].ToString(),
                    shirina = dt_mebel.Rows[i][4].ToString(),
                    visota = dt_mebel.Rows[i][5].ToString(),
                    
                };
                ListMebel.Items.Add(dataUser); // выводим строку в список 
            }
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            ListMebel.Items.Clear();
            ListMebel.Visibility = Visibility.Hidden;
            ListClient.Visibility = Visibility.Visible;
            LoadClient();
        }

        void LoadClient()
        {
            DataTable dt_clients = Select("SELECT * FROM [dbo].[Table_client]");
            for (int i = 0; i < dt_clients.Rows.Count; i++) // перебираем данные
            {
                clientS dataUser = new clientS() // создаём экземпляр класса
                {
                    codc = dt_clients.Rows[i][0].ToString(),
                    fio = dt_clients.Rows[i][1].ToString(),
                    adress = dt_clients.Rows[i][2].ToString(),
                    avans = dt_clients.Rows[i][3].ToString(),
                    cost = dt_clients.Rows[i][4].ToString(),

                };
                ListClient.Items.Add(dataUser); // выводим строку в список 
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            loginWin logwin = new loginWin();
            logwin.Show();
            this.Hide();
        }

        
    }
}
