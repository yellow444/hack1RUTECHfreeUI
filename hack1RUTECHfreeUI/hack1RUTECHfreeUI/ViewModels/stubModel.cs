using System;
using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace hack1RUTECHfreeUI.ViewModels
{
    public class stubModel : BaseViewModel
    {
        public string uri = "";
        public string BackgroundImg = "";
        public stubModel()
        {
            Title = "stub";
            if (uri.Contains("http"))
            {
                OpenWebCommand = new Command(async () => await Browser.OpenAsync(uri));
            }
            else
            {
                BackgroundImg = uri;
            }


        }

        public ICommand OpenWebCommand { get; }
    }
}