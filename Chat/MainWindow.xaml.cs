using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Chat
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string Login;
        string Password;
        string Server_IP;
        IPAddress ipserv;
        int Port;

        private void Input_TextBox_Login(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            while (null == textBox.Text)
            {
                MessageBox.Show("Имя пользователя не может быть пустым!");
            }

        }

        private void Input_Server_IP(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            //MessageBox.Show(textBox.Text);
        }

        private void Input_Server_Port(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            
            int.TryParse(textBox.Text, out Port);
        }

        private void Connect_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка соединения нажата");
            CheckInput(Port, Server_IP);
        }

        private void CheckInput(int Port, string Server_IP)
        {
            if (Port < 1 || Port > 65535)
            {
                MessageBox.Show("Порт сервера должен быть числом в пределах от 1 до 65535!");
            }

             if (!IPAddress.TryParse(Server_IP, out ipserv))
            {
                MessageBox.Show("Введите правильный IP адрес!");
            }
        }

        private void Escape_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
