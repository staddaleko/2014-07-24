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
using WcfService1;
using System.ServiceModel;

namespace WpfApplication1doWCF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool serviceStarted = false;
        ServiceHost myServiceHost = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (serviceStarted)
            {
                myServiceHost.Close();
                serviceStarted = false;
                button1.Content = "start service";

            }
            else
            {
                Uri baseAddress = new Uri("net.tcp://localhost:2202/Service1");

                NetTcpBinding binding = new NetTcpBinding();

                myServiceHost = new ServiceHost(typeof(Service1), baseAddress);
                myServiceHost.AddServiceEndpoint(typeof(IService1), binding, baseAddress);

                myServiceHost.Open();

                serviceStarted = true;
                button1.Content = "Stop Service";
            }
        }



        private void button1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
            if (serviceStarted)
            {
               myServiceHost.Close();
                MessageBox.Show("Kończę połączenie", "See ya!", MessageBoxButton.OK);
                myServiceHost.Close();
            }
            else
            {
                MessageBox.Show("Połączenie nieaktywne. Papapa!", "See ya!", MessageBoxButton.OK);
            }


        }

        private void Grid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
            if (serviceStarted)
            {
                myServiceHost.Close();
                MessageBox.Show("Kończę połączenie", "See ya!", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Połączenie nieaktywne. Papapa!", "See ya!", MessageBoxButton.OK);
            }
        }
    }
}
