using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AdminApplication
{
    /// <summary>
    /// Interaction logic for ShowRealEstates.xaml
    /// </summary>
    public partial class ShowRealEstates : Page
    {
        private DataAccessLayer.DataAccessLayer DAL = DataAccessLayer.DataAccessLayer.Instance;
        private string REST_URL = "RealEstateAPI/rest/realestates";

        public ShowRealEstates()
        {
            InitializeComponent();
            LoadData();
            foreach (Location loc in Enum.GetValues(typeof(Location)))
            {
                cbxLocation.Items.Add(loc);
            }
            foreach (RealEstateType type in Enum.GetValues(typeof(RealEstateType)))
            {
                cbxType.Items.Add(type);
            }
        }

        private async void LoadData()
        {
            string jsonRealEstate = await DAL.GetAsync(REST_URL);
            List<RealEstateModel> deserialized3 = JsonConvert.DeserializeObject<List<RealEstateModel>>(jsonRealEstate);
            dtgRealEstates.ItemsSource = deserialized3;
        }

        private void DtgRealEstates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RealEstateModel selectedItem = (RealEstateModel)dtgRealEstates.SelectedItem;
            if (selectedItem != null)
            {
                cbxLocation.SelectedItem = (Location)Enum.Parse(typeof(Location), selectedItem.Location);
                cbxType.SelectedItem = (RealEstateType)Enum.Parse(typeof(RealEstateType), selectedItem.Type);
                txtGardenSquaremeter.Text = selectedItem.GardenSquaremeter.ToString();
                txtParkinglots.Text = selectedItem.NumOfParkinglots.ToString();
                txtRooms.Text = selectedItem.Rooms.ToString();
                txtSquaremeter.Text = selectedItem.Squaremeter.ToString();
                lblPrice.Content = "";
            }
        }

        private async void BtnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RealEstateModel updateModel = new RealEstateModel(cbxType.SelectedItem.ToString(),
                cbxLocation.SelectedItem.ToString(), Convert.ToInt32(txtRooms.Text),
                Convert.ToDouble(txtSquaremeter.Text),
                Convert.ToDouble(txtGardenSquaremeter.Text),
                Convert.ToInt32(txtParkinglots.Text));
            RealEstateModel currentModel = (RealEstateModel)dtgRealEstates.SelectedItem;
            string stringPayload = await Task.Run(() => JsonConvert.SerializeObject(updateModel));
            StringContent httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await DAL.PutAsync(REST_URL + "/" + currentModel.IdRealEsate, httpContent);
            if (response.IsSuccessStatusCode)
            {
                LoadData();
                ResetForm();
            }
        }

        private void ResetForm()
        {
            cbxLocation.SelectedItem = null;
            cbxType.SelectedItem = null;
            txtGardenSquaremeter.Text = "";
            txtParkinglots.Text = "";
            txtRooms.Text = "";
            txtSquaremeter.Text = "";
            lblPrice.Content = "";
        }

        private void BtnCalculatePrice_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RealEstateModel currentModel = (RealEstateModel)dtgRealEstates.SelectedItem;
            if (currentModel != null)
            {
                RealEstate realEstate = RealEstateFactory.addRealEstate(
                    (Location)Enum.Parse(typeof(Location), currentModel.Location),
                    (RealEstateType)Enum.Parse(typeof(RealEstateType), currentModel.Type),
                    currentModel.Squaremeter,
                    currentModel.Rooms,
                    currentModel.GardenSquaremeter,
                    currentModel.NumOfParkinglots
                );
                lblPrice.Content = "Price: " + realEstate.getPrice() + "€";
            }
        }

        private async void BtnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RealEstateModel currentModel = (RealEstateModel)dtgRealEstates.SelectedItem;
            if (currentModel != null)
            {
                HttpResponseMessage response = await DAL.DeleteAsync(REST_URL + "/" + currentModel.IdRealEsate);
                if (response.IsSuccessStatusCode)
                {
                    LoadData();
                    ResetForm();
                }
            }
        }
    }
}
