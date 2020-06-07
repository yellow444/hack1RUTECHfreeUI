using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace hack1RUTECHfreeUI.Views.Profile
{
    /// <summary>
    /// Page to show chat profile page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatProfilePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatProfilePage" /> class.
        /// </summary>
        public ChatProfilePage()
        {
            try
            {
                InitializeComponent();
                LbMailentry.Text = App.Api.email;
                LbNameentry.Text = App.Api.name + " " + App.Api.surnam;
                if (App.OwnProfileImage != null)
                {
                    ProfileImage.Source = ImageSource.FromStream(() => new MemoryStream(App.OwnProfileImage));
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ОK");
            }

        }
    }
}