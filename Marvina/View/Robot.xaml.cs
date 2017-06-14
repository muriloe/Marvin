using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Marvina.Properties;
using Marvina.Services;
using System.Threading.Tasks;
using Marvina.Model;

namespace Marvina.View
{
    public partial class Robot : ContentPage
    {
        AzureService azureService;

        public Robot()
        {
            InitializeComponent();
            Singleton.GetInstance();
            TitleLastActionStack.BackgroundColor = AppProperties.getLightColor();
			facebookStack.BackgroundColor = AppProperties.getFaceBookCollor();
            threadCheckLoginAsync();
            azureService = DependencyService.Get<AzureService>();

		}

        async void threadCheckLoginAsync()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    if (Singleton.getUserName() != null)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                    {
						    LstAction.BeginRefresh();

						    userName.Text = Singleton.getUserName();
                            Option op = new Option();
                            op.selectOptionTitle = "Login com Facebook";
                            op.selectOptionDescription = Singleton.getUserName();
                            Singleton.addListOfOption(op);
                            var listOption = Singleton.getListOfOption();
                            LstAction.ItemsSource = listOption;
                            LstAction.EndRefresh();

                    });
                        break;
                    }
                }
            });
        }

        void BtnFacebookClicked(object sender, EventArgs e)
		{
            doLoginAsync();
		}

        public void doLoginAsync()
        {
            var a = azureService.LoginAsync();

        }
    }
}
