using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

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
            }
        }

        private async void BtnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RealEstateModel updateModel = new RealEstateModel(
                cbxType.SelectedItem.ToString(),
                cbxLocation.SelectedItem.ToString(),
                Convert.ToInt32(txtRooms.Text),
                Convert.ToDouble(txtSquaremeter.Text.Replace(",", "."), CultureInfo.InvariantCulture),
                Convert.ToDouble(txtGardenSquaremeter.Text.Replace(",", "."), CultureInfo.InvariantCulture),
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
        }

        private void BtnShowDetails_Click(object sender, System.Windows.RoutedEventArgs e)
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
                NavigationService.Navigate(new Details(realEstate));
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

        private void IntNumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DoubleNumberValidation(object sender, TextCompositionEventArgs e)
        {
            // Here e.Text is string so we need to convert it into char
            char ch = e.Text[0];

            if ((char.IsDigit(ch) || ch == '.'))
            {
                //Here TextBox1.Text is name of your TextBox
                TextBox sen = (TextBox)sender;
                if (ch == '.' && sen.Text.Contains('.'))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private bool CheckInputFields()
        {
            if (cbxLocation.SelectedItem == null)
            {
                return false;
            }
            else if (cbxType.SelectedItem == null)
            {
                return false;
            }
            else if (txtGardenSquaremeter.Text == "")
            {
                return false;
            }
            else if (txtParkinglots.Text == "")
            {
                return false;
            }
            else if (txtSquaremeter.Text == "")
            {
                return false;
            }
            else if (txtRooms.Text == "")
            {
                return false;
            }
            return true;
        }

        private void EnableButtons(bool enable)
        {
            btnDelete.IsEnabled = enable;
            btnSave.IsEnabled = enable;
            btnShowDetails.IsEnabled = enable;
        }

        private void CbxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButtons(CheckInputFields());
        }

        private void CbxLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButtons(CheckInputFields());
        }

        private void TxtRooms_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableButtons(CheckInputFields());
        }

        private void TxtSquaremeter_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtSquaremeter.Text.Replace(",", ".");
            EnableButtons(CheckInputFields());
        }

        private void TxtGardenSquaremeter_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtGardenSquaremeter.Text.Replace(",", ".");
            EnableButtons(CheckInputFields());
        }

        private void TxtParkinglots_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableButtons(CheckInputFields());
        }
    }
}
