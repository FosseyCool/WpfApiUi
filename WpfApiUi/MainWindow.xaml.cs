using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using WpfApiUi.Models;

namespace WpfApiUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();

        public MainWindow()
        {
            client.BaseAddress = new Uri("https://localhost:44385/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.
                MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void btnLoadOrders_Click(object sender, RoutedEventArgs e)
        {
            this.GetOrders();
        }

        private async void GetOrders()
        {
            lblMessage.Content = "";
            var response = await client.GetStringAsync("Orders");
            var orders = JsonConvert.DeserializeObject<List<Order>>(response);
            dgOrders.DataContext = orders;
        }

        private async void SaveOrder(Order order)
        {
            await client.PostAsJsonAsync("Orders", order);
        }

        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = new Order()
            {
                SenderCity = txtSenderCity.Text,

                SenderAddress = txtSenderAddress.Text,

                RecipientCity = txtRecipientCity.Text,

                RecipientAddress = txtRecipientAddress.Text,

                Weight = Convert.ToInt32(txtWeight.Text),

                Data=Convert.ToDateTime(txtData.Text),
                

            };

          
            this.SaveOrder(order);
            txtRecipientAddress.Text = "";
            txtRecipientCity.Text = "";
            txtSenderAddress.Text = "";
            txtSenderCity.Text = "";
            txtWeight.Text = 0.ToString();
            txtData.Text = "";
        }
    }
}
