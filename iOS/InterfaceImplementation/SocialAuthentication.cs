using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marvina.Interfaces;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Marvina.Helpers;
using Marvina.iOS.InterfaceImplementation;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace Marvina.iOS.InterfaceImplementation
{
    public class SocialAuthentication : IAuthentication
    {
        public SocialAuthentication()
        {

        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                var current = GetController();
                var user = await client.LoginAsync(current, provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private UIKit.UIViewController GetController(){
            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;

            if (root == null) return null;

            var current = root;

            while(current.PresentedViewController != null){
                current = current.PresentedViewController;
            }

            return current;
        }
    }
}

