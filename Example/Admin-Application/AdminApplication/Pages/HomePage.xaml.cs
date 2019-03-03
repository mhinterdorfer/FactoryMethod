using System.Windows.Controls;
using System.Windows.Navigation;

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
            NavigationService.Navigate(new CreateRealEstate());
        }

        private void BtnShowRealEstates_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowRealEstates());
        }
    }
}
