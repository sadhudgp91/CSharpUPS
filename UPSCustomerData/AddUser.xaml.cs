using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UPSCustomerData.ControlEngine;


namespace UPSCustomerData
{

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            txtLabel.Content = "User Management";

        }

        private async void Add_User_Click(object sender, RoutedEventArgs e)
        {
            var response = await RestAPIFunctions.Post(txtName.Text, txtEmail.Text, cmbGender.Text,cmbStatus.Text);
            //EmployeeData.ItemsSource = RestAPIFunctions.BeautifyJson(response);
            //Refresh the table!
            _ = RestAPIFunctions.GetAll();
        }

    }

}
