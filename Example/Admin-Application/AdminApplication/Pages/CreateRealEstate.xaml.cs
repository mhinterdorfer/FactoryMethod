using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            foreach (Location loc in Enum.GetValues(typeof(Location)))
            {
                cbxLocation.Items.Add(loc);
            }
            foreach (RealEstateType type in Enum.GetValues(typeof(RealEstateType)))
            {
                cbxTypes.Items.Add(type);
            }
        }

        private async void BtnCreate_Click(object sender, RoutedEventArgs e)
        {

            RealEstate realEstate = RealEstateFactory.addRealEstate(
                (Location)Enum.Parse(typeof(Location), cbxLocation.SelectedItem.ToString()),
                (RealEstateType)Enum.Parse(typeof(RealEstateType), cbxTypes.SelectedItem.ToString()),
                Convert.ToDouble(txtSquaremeter.Text, CultureInfo.InvariantCulture),
                Convert.ToInt32(txtRooms.Text),
                Convert.ToDouble(txtGardenSquaremeter.Text, CultureInfo.InvariantCulture),
                Convert.ToInt32(txtParkinglots.Text));

            if (realEstate != null)
            {
                txtResult.Text = "Result: \n" + realEstate.ToString();
                string stringPayload = await Task.Run(() => JsonConvert.SerializeObject(new RealEstateModel(realEstate.GetType().Name, realEstate.getLocation().ToString(), realEstate.getRooms(), realEstate.getSquaremeter(), realEstate.getGarden_squaremeter(), realEstate.getNum_of_parkinglots())));
                StringContent httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
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
            else
            {
                txtResult.Text = "Not possible to create " + cbxTypes.SelectedItem.ToString() + " in " + cbxLocation.SelectedItem.ToString() + ".";
            }
        }

        private void BtnShowInList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowRealEstates());
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
            else if (cbxTypes.SelectedItem == null)
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

        private void CbxLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCreate.IsEnabled = CheckInputFields();
        }

        private void CbxTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCreate.IsEnabled = CheckInputFields();
        }

        private void TxtParkinglots_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnCreate.IsEnabled = CheckInputFields();
        }

        private void TxtRooms_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnCreate.IsEnabled = CheckInputFields();
        }

        private void TxtSquaremeter_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnCreate.IsEnabled = CheckInputFields();
        }

        private void TxtGardenSquaremeter_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnCreate.IsEnabled = CheckInputFields();
        }
    }
}
