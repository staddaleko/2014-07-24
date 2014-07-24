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
using System.ServiceModel;
using WcfService1;

namespace AplikacjaKliencka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IService1 studentSvc;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            EndpointAddress address = new EndpointAddress(new Uri("Net.tcp://localhost:2202/Service1"));

            NetTcpBinding binding = new NetTcpBinding();

            ChannelFactory<IService1> factory = new ChannelFactory<IService1>(binding, address);
            studentSvc = factory.CreateChannel();
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            string imie = TextImie.Text.ToString();
            string nazwisko = TextNazwisko.Text.ToString();
            studentSvc.SetStudent(imie, nazwisko);
        }

        private void ButtonPobierz_Click(object sender, RoutedEventArgs e)
        {
            StudentKlasa S = new StudentKlasa(); //czy tabela?
            int id = int.Parse(TextID.Text.ToString());
            S = studentSvc.GetStudent(id);
            List<StudentKlasa> Lista = new List<StudentKlasa>();
            Lista.Add(S);
            StudentDataGrid.ItemsSource = Lista;
        }

        
    }
}
