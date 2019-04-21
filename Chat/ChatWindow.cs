using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chat
{
    public partial class ChatWindow : Window
    {
        private DateTime newestMessageDate = DateTime.Now;
        private string login = MainWindow.Login;
        private static List<Message> messages = new List<Message>(1000);
        public event EventHandler<Message> NewMessage;
        //InstanceContext inst;
        //ChatService.SendChatServiceClient chatClient = new ChatService.SendChatServiceClient(inst);
        //IClient client = MainWindow._chatServerClient;

        //StartCheckNewMessagesAssync();

        public ChatWindow()
        {
            InitializeComponent();
        }

        private void Message_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Send_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartCheckNewMessagesAssync()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        CheckNewMessages();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Не удается подключиться к серверу для проверки новых сообщений.");
                    }
                    finally
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
        }

        private void CheckNewMessages()
        {
            var newMessages = MainWindow._chatServerClient.GetNewMessages(newestMessageDate);
            foreach (var newMessage in newMessages)
            {
                NewMessage(this, newMessage);
            }

            newestMessageDate = DateTime.Now;
        }

        public void SendMessage(string text)
        {
            try
            {
                client.SendMessage(text, login);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось отправить сообщение на сервер. Проверьте подключение и попробуйте отправить сообщение снова.");
            }
        }

        public IEnumerable<Message> GetNewMessages(DateTime newMessageDate)
        {
            var newMessages = messages
                .Where(m => m.SentDateTime > newMessageDate);

            return newMessages;
        }
    }
}
