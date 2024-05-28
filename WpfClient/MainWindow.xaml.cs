using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientTCP tcp;
        private string txtValue;
        public MainWindow()
        {
            InitializeComponent();
            tcp = new ClientTCP("127.0.0.1", 8000);
        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtValue = textBoxNum.Text;
            string serverRes = tcp.Stream(txtValue);
            if(serverRes != "exit")
            {
                ResListBox.Items.Add(serverRes);
            } else
            {
                MessageBox.Show("Client => EXIT");
            }

        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            txtValue = "exit";
            if (tcp.Stream(txtValue) == "exit")
            {
                MessageBox.Show("Client => EXIT");
            }
        }
    }
}