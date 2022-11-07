using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.RequestServiceReference;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        RequestServiceClient Client = new RequestServiceClient();
        public MainWindow()
        {
            InitializeComponent();

            RequestServiceReference.GetRequestList data = new RequestServiceReference.GetRequestList();
            
            
            data = Client.GetInfo();
            DataTable dt = new DataTable();
            dt = data.ReqTble;
            Thread.Sleep(9000);
            dtRequest.ItemsSource = dt.DefaultView;
           
           
        }

         
           


       

        private void dtRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected!=null)
            {
                txtRequestID.Text = row_selected["RequestId"].ToString();
            }

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            int Id = Convert.ToInt32(txtRequestID.Text);
            if ((bool)rbtApprove.IsChecked)
            {
                Client.UpdateRequest(Id, true);

            }
            else if ((bool)rbtReject.IsChecked)
            {
                Client.UpdateRequest(Id, false);
            }
            MessageBox.Show("Status Updated Succesfully");
        }
    }
}
