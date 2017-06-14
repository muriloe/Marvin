using System;
using System.Threading.Tasks;
using Marvina.Helpers;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Marvina.Interfaces;
using Marvina.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;

[assembly: Xamarin.Forms.Dependency(typeof(AzureService))]
namespace Marvina.Services
{

    public class AzureService 
    {

        static readonly string AppUrl = "https://honestmarvin.azurewebsites.net/";

        public MobileServiceClient Client { get; set; } = null;

        public static bool UseAuth { get; set; } = false;

        public void Initialize(){
            Client = new MobileServiceClient(AppUrl);

            if(!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId)){
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync(){
            Initialize();
            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);
            if(user == null){
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () => {
                    await Application.Current.MainPage.DisplayAlert("Eita","Deu ruim","Ok né");   
                });

                return false;
            }
            else{
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
                try{
					List<AppServiceIdentity> identities = null;
					identities = await Client.InvokeApiAsync<List<AppServiceIdentity>>("/.auth/me");
					var name = identities[0].UserClaims.Find(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;

                    Singleton.setUserName(name);
                    var useraa = Singleton.getUserName();

				}catch(Exception ex){
                    var ass = 23;
                }


			}

            return true;
        }



    }
}

