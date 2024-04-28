using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TextBox = System.Windows.Controls.TextBox;

namespace MotorMaster
{
    /// <summary>
    /// Логика взаимодействия для Automobile.xaml
    /// </summary>
    public partial class Automobile : Window
    {
        private readonly object value;

        public string ConnectionString { get; private set; }

        public Automobile()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Home newWindow = new Home();
            newWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Catalog newWindow = new Catalog();
            newWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=AORUS;Initial Catalog=Application;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO HarAuto (Number,Brand,Model,Release,Changes,Install) values (@Number,@Brand,@Model,@Release,@Patronymic,@Changes,@Install)", connection))
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Number", box1.Text);
                    command.Parameters.AddWithValue("@Brand", box2.Text);
                    command.Parameters.AddWithValue("@Model", box3.Text);
                    command.Parameters.AddWithValue("@Release", box4.Text);
                    command.Parameters.AddWithValue("@Changes", box5.Text);
                    command.Parameters.AddWithValue("@Install", box6.Text);
                    command.Parameters.AddWithValue("@Patronymic", value);
                }

                System.Windows.MessageBox.Show("Ваша заявка отправлена, ждите ответа", "Готово", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
            }
        }
    }
}
