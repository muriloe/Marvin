using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Marvina.Properties;
using Marvina.Services;
using System.Threading.Tasks;

namespace Marvina.View
{
    public partial class Robot : ContentPage
    {
        AzureService azureService;

        public Robot()
        {
            InitializeComponent();
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
                        userName.Text = Singleton.getUserName();
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
