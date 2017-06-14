using System;

using Xamarin.Forms;

namespace Marvina.View
{
    public class Configurations : ContentPage
    {
        public Configurations()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

