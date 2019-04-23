using Chat.ChatServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chat
{

    public partial class ChatWindow : Window, INotifyPropertyChanged
    {
        private IServer _chatClient;
        private DateTime newestMessageDate = DateTime.UtcNow;
        private string login = MainWindow.Login;
        //private string MessageText;



        public ChatWindow(IServer chatClient)
        {
            _chatClient = chatClient;
            MessagesList = new ObservableCollection<Message>();

            InitializeComponent();
            StartCheckNewMessagesAssync();
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string MessageText)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(MessageText));
        }

        private string _messageText;
        public string MessageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                OnPropertyChanged(nameof(MessageText));
            }
        }

        public ObservableCollection<Message> MessagesList { get; set; }

        private void StartCheckNewMessagesAssync()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        Dispatcher.Invoke(() => CheckNewMessages());
                    }
                    catch (Exception ex)
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
            var newMessages = _chatClient.GetNewMessages(newestMessageDate);
            foreach (var newMessage in newMessages)
            {
                MessagesList.Add(newMessage);
            }

            newestMessageDate = DateTime.UtcNow;
        }

        private void SendMessage(string text)
        {
            try
            {
                _chatClient.SendMessage(text, login);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось отправить сообщение на сервер. Проверьте подключение и попробуйте отправить сообщение снова.");
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage(MessageText);
            MessageText = "";
        }
    }
}
