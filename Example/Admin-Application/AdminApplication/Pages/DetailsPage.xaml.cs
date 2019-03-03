using System.Windows.Controls;

namespace AdminApplication
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Page
    {
        public Details(RealEstate realEstate)
        {
            InitializeComponent();
            ShowRealEstate(realEstate);
        }

        private void ShowRealEstate(RealEstate realestate)
        {
            lblGardenSquaremetersDetail.Content = realestate.getGarden_squaremeter() + " m2";
            lblLocationDetail.Content = realestate.getLocation();
            lblParkinglotsDetail.Content = realestate.getNum_of_parkinglots();
            lblPriceDetail.Content = realestate.getPrice() + " €";
            lblRoomsDetail.Content = realestate.getRooms();
            lblSquaremetersDetail.Content = realestate.getSquaremeter() + " m2";
            lblTypeDetail.Content = realestate.GetType();
        }
    }
}
