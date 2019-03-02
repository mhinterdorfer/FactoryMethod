using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
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

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            RealEstate realEstate = RealEstateFactory.addRealEstate((Location)Enum.Parse(typeof(Location), cbxLocation.SelectedItem.ToString()),
                (RealEstateType)Enum.Parse(typeof(RealEstateType), cbxTypes.SelectedItem.ToString()), Convert.ToDouble(txtSquaremeter.Text),
                Convert.ToInt32(txtRooms.Text), Convert.ToDouble(txtGardenSquaremeter.Text), Convert.ToInt32(txtParkinglots.Text));
            txtResult.Text = "Result: \n" + realEstate.ToString();
        }

        private async void getAll()
        {
            string getRE = "RealEstateAPI/rest/realestates";
            string jsonRealEstate = await DAL.GetAsync(getRE);
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
    }
}
