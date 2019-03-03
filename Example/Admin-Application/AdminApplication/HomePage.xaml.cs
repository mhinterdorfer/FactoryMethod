using System.Windows.Controls;
using System;
using System.Windows.Navigation;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdminApplication
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void btnCreateRealEstate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateRealEstate());
        }

        private void BtnShowRealEstates_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShowRealEstates());
        }
    }
}
