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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_Login(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            MessageBox.Show(textBox.Text);
        }

        private void Server_IP(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            MessageBox.Show(textBox.Text);
        }

        private void Server_Port(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            MessageBox.Show(textBox.Text);
        }

        private void Connect_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка соединения нажата");
        }

        private void Escape_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
