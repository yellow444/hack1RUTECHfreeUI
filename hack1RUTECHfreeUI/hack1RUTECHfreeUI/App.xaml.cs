using hack1RUTECHfreeUI.ViewModels.Forms;
using hack1RUTECHfreeUI.Views.Forms;
using hack1RUTECHfreeUI.Web;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static hack1RUTECHfreeUI.Web.api;

namespace hack1RUTECHfreeUI
{
    public partial class App : Application
    {
        public static string DefaultImageId = "default_image";
        public static string ImageIdToSave = null;
        public static byte[] OwnProfileImage = null;
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public static Inwike2020 Api;
        public static Page AppMainPage;
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY4MTg1QDMxMzgyZTMxMmUzMGsyVmRHT2JvdmFJblRWbitnQ3EvSU1BYWhDenVRM3hKOWVSamMvK0pEQ0k9");
            InitializeComponent();
            MainPage = new hack1RUTECHfreeUI.Views.Forms.SimpleLoginPage();
            AppMainPage = MainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public static void SignUp()
        {


        }
    }
}
