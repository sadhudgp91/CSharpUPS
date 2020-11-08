using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using Microsoft.Office.Interop.Excel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System.Windows.Controls.Primitives;
using UPSCustomerData.ControlEngine;
using Window = System.Windows.Window;
using TextBox = System.Windows.Controls.TextBox;
using System.IO;
using Microsoft.Win32;
using System.Data;
using System.Collections;
using CsvHelper;
using Microsoft.Office.Core;

namespace UPSCustomerData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtLabel.Content = "UPS Employee Details";
            txtLabelUser.Content = "Welcome " +  "\n" + Environment.UserName;
         

        }

        public async void BindEmployeeList()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://gorest.co.in/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");

            client.DefaultRequestHeaders.Add("Authorization", "Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("public-api/users").Result;

   

            if (response.IsSuccessStatusCode)
            {
                var json_daily_forecast = await response.Content.ReadAsStringAsync();

                var myObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Jsonobjects>(json_daily_forecast);

                string jsonData = JsonConvert.SerializeObject(json_daily_forecast, Formatting.None);

                grdEmployee.ItemsSource = myObject.data;
                              
                SortDataGrid(grdEmployee);
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

        }


        public static void SortDataGrid(DataGrid dataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            var column = dataGrid.Columns[columnIndex];

            // Clear current sort descriptions
            dataGrid.Items.SortDescriptions.Clear();

            // Add the new sort description
            dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));

            // Apply sort
            foreach (var col in dataGrid.Columns)
            {
                col.SortDirection = null;
            }
            column.SortDirection = sortDirection;

            // Refresh items to display sort
            dataGrid.Items.Refresh();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            var response = await DeleteUser(txtSearchID.Text.Trim());
            JToken parseJson = JToken.Parse(response);
            var newJson = parseJson.ToString(Formatting.Indented);

            txtSearchID.Text = "Enter Search Criteria";
            //Refresh the table!
            BindEmployeeList();

            

        }

        private async Task<string> DeleteUser(string id)
        {
            var BaseAddress = new Uri("https://gorest.co.in/");
            var url = "public-api/users/" + id;
            string uriToDelete = BaseAddress + url;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                using (HttpResponseMessage response = await client.DeleteAsync(uriToDelete))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("User deleted successfully!");
                        
                    }
                    else
                    {
                        MessageBox.Show("Error while deleting user! Check Authorization!");
                    }

                    using (HttpContent content = response.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if(data!=null)
                        {
                            return data;

                        }
                    }

                }

            }

            return string.Empty;
           
           
        }


       



        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var response = await RestAPIFunctions.SearchUser(txtUnivSearch.Text);
            //var json_daily_forecast = await response.Content.ReadAsStringAsync();


            //string jsonData = JsonConvert.SerializeObject(response, Formatting.None);

            //grdEmployee.ItemsSource = jsonData.data;

        
            //var newJson = parseJson.ToString(Formatting.Indented);

            //var json = "[" + newJson + "]";

            //Datum[] items = JsonConvert.DeserializeObject<Datum[]>(json);

        
            //var people = JsonConvert.DeserializeObject<List<Person>>(json);

            grdEmployee.ItemsSource = RestAPIFunctions.BeautifyJson(response);


        }


        public class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }

        private  void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            var wpfWindow = new UPSCustomerData.Window1();
            //var wpfWindow = new WpfApplication1.MainWindow();
            wpfWindow.Show();

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://gorest.co.in/");

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            //var date1 = new DateTime(2008, 5, 1, 8, 30, 52);

            //client.DefaultRequestHeaders.Accept.Add(
            //   new MediaTypeWithQualityHeaderValue("application/json"));
            //var employee = new Datum();

            //employee.created_at = date1; 
            //employee.updated_at = date1;

            //var response = client.PostAsJsonAsync("public-api/users", employee).Result;

            //if (response.IsSuccessStatusCode)
            //{
                
               
            //    BindEmployeeList();
            //}
            //else
            //{
            //    MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            //}
        }

        private static int id = 1;
        static int generateId()
        {
            return id++;
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            BindEmployeeList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindEmployeeList();
        }

        private void CreateDynamicStatusBar()
        {
            StatusBar sBar = new StatusBar();
            sBar.Height = 30;
            sBar.Background = new SolidColorBrush(Colors.LightBlue);

            TextBox tb = new TextBox();
            tb.Text = "This is a status bar";
            sBar.Items.Add(tb);
            
        }





        // Excel Export Stuff

        private string WriteDataTable(System.Data.DataTable dataTable)
        {
            string output = "";

            // Need to get the last column so I know when to add a new line instead of comma.
            string lastColumnName = dataTable.Columns[dataTable.Columns.Count - 1].ColumnName;

            // Get the headers from the datatable.
            foreach (DataColumn column in dataTable.Columns)
            {
                if (lastColumnName != column.ColumnName)
                {
                    output += (column.ColumnName.ToString() + ",");
                }
                else
                {
                    output += (column.ColumnName.ToString() + "\n");
                }
            }
            // Get the actual data from the datatable.
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (lastColumnName != column.ColumnName)
                    {
                        output += (row[column].ToString() + ",");
                    }
                    else
                    {
                        output += (row[column].ToString() + "\n");
                    }
                }
            }
            return output;
        }


        public bool SaveDataGridToCSV(System.Windows.Controls.DataGrid dataGrid, string Filename)
        {
            bool fileError = false;
            bool exportSuccessful = false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save CSV Files";
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.FileName = Filename;
            if (saveFileDialog.ShowDialog() == true)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    try
                    {
                        File.Delete(saveFileDialog.FileName);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("There was an error processing your export request." + ex.Message);
                    }
                }
                if (!fileError)
                {
                    try
                    {
                        string path = System.IO.Path.GetFullPath(saveFileDialog.FileName);
                        createcsvfile(dataGrid, path);
                        exportSuccessful = true;
                        //File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                        //MessageBox.Show("Data Exported Successfully.", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Recordset, no data to Export!", "Info");
                }

            }

            return exportSuccessful;
        }
               



        private void createcsvfile(System.Windows.Controls.DataGrid dataGrid, string FilePath)
        {
            dataGrid.SelectAllCells();
            dataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dataGrid);
            dataGrid.UnselectAllCells();
            String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
            File.AppendAllText(FilePath, result, UnicodeEncoding.UTF8);
        }


        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

            {
                string ExportFileName = "UPS_CustomerDetails";
                bool result = SaveDataGridToCSV(grdEmployee, ExportFileName);//pass the Datagrid and Exportname
                if (result == true)
                {
                    System.Windows.MessageBox.Show("Exported successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }



    // Data Models

    public class Obj
    {
        public Obj(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }
    }


    public class Pagination
    {
        public int total { get; set; }
        public int pages { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }

    public class Meta
    {
        public Pagination pagination { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Gender gender { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
    public enum Gender
    {
        Male,
        Female
    };

    public enum Status
    {
        Active,
        InActve
    };

    public class Rootobject
    {
        public int code { get; set; }
        public Meta meta { get; set; }

        //public Datum[] data { get; set; }

        public List<Datum> data { get; set; }
    }


    public class Jsonobjects
    {
        public int id { get; set; }
        public Meta meta { get; set; }

        public Datum[] data { get; set; }

        //public List<UPSCustomerDetails> data { get; set; }
    }


    public class UPSCustomerDetails
    {

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("gender")]
        public Gender gender { get; set; }
       
        [JsonProperty("status")]
        public Status status { get; set; }

        [JsonProperty("created_at")]
        public string created_at { get; set; }

        [JsonProperty("updated_at")]
        public string updated_at { get; set; }

        //public List<UPSCustomerDetails> userdetails { get; set; }

        //public static IList<UPSCustomerDetails> products = new List<UPSCustomerDetails>();
    }
    }

}
