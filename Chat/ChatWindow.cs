using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Chat
{
    public partial class ChatWindow : Window
    {
        private DateTime newestMessageDate;
        public ChatWindow()
        {
            InitializeComponent();
        }

        private void Message_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Connect_Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
