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
using Chat.ChatServer;
using System.ServiceModel;
using System.Net.Sockets;

namespace Chat
{

    public partial class MainWindow : Window
    {
        private IServer _chatServerClient;

        public MainWindow()
        {
#if DEBUG
            Login = "admin";
            Password = "12345";
            Server_IP = "127.0.0.1";
            Port = 1024;
#endif

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
            Login = textBox.Text;
        }

        private void Input_Password(object sender, RoutedEventArgs e)
        {
            Password = passwordBox.Password;
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
            if (CheckInput(Port, Server_IP, Login) & CheckConnection())
            {
                GoToChatWindow();
            }

        }

        private bool CheckInput(int Port, string Server_IP, string Login)
        {
            if (String.IsNullOrWhiteSpace(Login))
            {
                MessageBox.Show("Имя пользователя не может быть пустым!");
                return false;
            }

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

        private bool CheckConnection()
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(Server_IP, Port);
                    return true;
                }
                catch (Exception)
                {
                    MessageBox.Show($"Невозможно соединиться с сервером по адресу {Server_IP}:{Port}. Проверьте правильность настроек подключения.");
                    return false;
                }
            }
        }

        private void GoToChatWindow()
        {
            _chatServerClient = new ServerClient("NetTcpBinding_IServer", $"net.tcp://{Server_IP}:{Port}/Server");
            var isValidUser = _chatServerClient.CheckUser(Login, Password);
            if (!isValidUser)
            {
                MessageBox.Show("Учетные данные неверны. Проверьте раскладку, а также не включена ли клавиша Caps Lock.");
                return;
            }

            ChatWindow chatWindow = new ChatWindow();
            chatWindow.Show();
            this.Close();
        }

        
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
