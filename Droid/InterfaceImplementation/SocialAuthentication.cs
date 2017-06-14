using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marvina.Droid.InterfaceImplementation;
using Marvina.Interfaces;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Marvina.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace Marvina.Droid.InterfaceImplementation
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
                var user = await client.LoginAsync(Forms.Context, provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;
                return user;
            }
            catch(Exception ex){
                throw;
            }
        }
    }
}

