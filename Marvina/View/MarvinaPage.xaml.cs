using Xamarin.Forms;
using Marvina.View;
using Marvina.Properties;

namespace Marvina
{
    public partial class MarvinaPage : TabbedPage
    {
        public MarvinaPage()
        {
            InitializeComponent();

            var robotPage = new NavigationPage(new Robot());
			robotPage.Title = "Fala comigo";
			robotPage.Icon = "robot.png";
            robotPage.BarBackgroundColor = AppProperties.getLightColor();

            var config = new NavigationPage(new Config());
			config.Title = "Ajustar Parafasos";
			config.Icon = "config.png";
			config.BarBackgroundColor = AppProperties.getLightColor();

			Children.Add(robotPage);
			Children.Add(config);
        }
    }
}
