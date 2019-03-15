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
            Server_IP = textBox.Text;
        }

        private void Input_Server_Port(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int.TryParse(textBox.Text, out Port);
        }

        private void Connect_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка соединения нажата");
            if (CheckInput(Port, Server_IP))
            {
                //TODO CONNECT METHOD
                GoToChatWindow();
            }

        }

        private bool CheckInput(int Port, string Server_IP)
        {
            if (Port < 1 || Port > 65535)
            {
                MessageBox.Show("Порт сервера должен быть числом в пределах от 1 до 65535!");
                return false;
            }

            if (!IPAddress.TryParse(Server_IP, out ipserv))
            {
                MessageBox.Show("Введите правильный IP адрес!");
                return false;
            }
            return true;
        }

        private void GoToChatWindow()
        {
            ChatWindow chatWindow = new ChatWindow();
            chatWindow.Show();
            this.Close();
        }

        private void Escape_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
