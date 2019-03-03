using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AdminApplication
{
    /// <summary>
    /// Interaction logic for CreateRealEstate.xaml
    /// </summary>
    public partial class CreateRealEstate : Page
    {
        public List<string> locations = new List<string>();
        private DataAccessLayer.DataAccessLayer DAL = DataAccessLayer.DataAccessLayer.Instance;
        private string REST_URL = "RealEstateAPI/rest/realestates";
        public CreateRealEstate()
        {
            InitializeComponent();
            foreach(Location loc in Enum.GetValues(typeof(Location)))
            {
                cbxLocation.Items.Add(loc);
            }
            foreach(RealEstateType type in Enum.GetValues(typeof(RealEstateType)))
            {
                cbxTypes.Items.Add(type);
            }
        }

        private async void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            RealEstate realEstate = RealEstateFactory.addRealEstate((Location)Enum.Parse(typeof(Location), cbxLocation.SelectedItem.ToString()),
                (RealEstateType)Enum.Parse(typeof(RealEstateType), cbxTypes.SelectedItem.ToString()), Convert.ToDouble(txtSquaremeter.Text),
                Convert.ToInt32(txtRooms.Text), Convert.ToDouble(txtGardenSquaremeter.Text), Convert.ToInt32(txtParkinglots.Text));
            txtResult.Text = "Result: \n" + realEstate.ToString();

            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(new RealEstateModel(realEstate.GetType().Name, realEstate.getLocation().ToString(), realEstate.getRooms(), realEstate.getSquaremeter(), realEstate.getGarden_squaremeter(), realEstate.getNum_of_parkinglots())));
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await DAL.PostAsync(REST_URL, httpContent);
            if (response.IsSuccessStatusCode)
            {
                btnShowInList.IsEnabled = true;
            }
            else
            {
                btnShowInList.IsEnabled = false;
            }
        }

        private async void getAll()
        {
            string jsonRealEstate = await DAL.GetAsync(REST_URL);
            dynamic deserialized3 = JsonConvert.DeserializeObject(jsonRealEstate);
            foreach (var obj in deserialized3)
            {
                Console.WriteLine(obj["gardenSquaremeter"]);
                RealEstate realEstate = RealEstateFactory.addRealEstate(
                    (Location)Enum.Parse(typeof(Location), obj["location"].ToString()),
                    (RealEstateType)Enum.Parse(typeof(RealEstateType), obj["type"].ToString()), 
                    Convert.ToDouble(obj["squaremeter"]),
                    Convert.ToInt32(obj["rooms"]), 
                    Convert.ToDouble(obj["gardenSquaremeter"]), 
                    Convert.ToInt32(obj["numOfParkinglots"]));

                txtResult.Text += "\n" + realEstate.ToString() + "\n";
            }
        }

        private void BtnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            getAll();
        }

        private void BtnShowInList_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShowRealEstates());
        }
    }
}
