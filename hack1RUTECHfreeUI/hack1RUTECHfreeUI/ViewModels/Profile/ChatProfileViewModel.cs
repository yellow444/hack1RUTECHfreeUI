using hack1RUTECHfreeUI.Views.Navigation;
using hack1RUTECHfreeUI.Views.Profile;
using hack1RUTECHfreeUI.Web;

using Newtonsoft.Json;

using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

using System;
using System.IO;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

using Color = Xamarin.Forms.Color;

namespace hack1RUTECHfreeUI.ViewModels.Profile
{
    /// <summary>
    /// ViewModel for profile page
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ChatProfileViewModel : TabbedPage
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ProfileViewModel" /> class
        /// </summary>
        public ChatProfileViewModel()
        {
            try
            {
                this.EditCommand = new Command(this.EditButtonClicked);
                this.OpenCommand = new Command(this.OpenButtonClicked);
                this.AvailableCommand = new Command(this.AvailableStatusClicked);
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ОK");
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the edit button is clicked.
        /// </summary>
        public Command EditCommand { get; set; }
        public Command OpenCommand { get; set; }
        public string LbMail { get; set; }
        public string EditorTel { get; set; }
        public string LbName { get; set; }
        /// <summary>
        /// Gets or sets the command that is executed when the available status is clicked.
        /// </summary>
        public Command AvailableCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the notification option is clicked.
        /// </summary>
        public Command NotificationCommand { get; set; }
        public object Plugin { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the edit button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void EditButtonClicked(object obj)
        {
            try
            {

                var status = PermissionStatus.Unknown;

                status = await CrossPermissions.Current.CheckPermissionStatusAsync<CameraPermission>();
                //  await Application.Current.MainPage.DisplayAlert("Pre - Results", status.ToString(), "OK");


                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }
                await CrossMedia.Current.Initialize();
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());

                if (file == null)
                    return;
                byte[] imageAsBytes = null;
                using (var memoryStream = new MemoryStream())
                {
                    file.GetStream().CopyTo(memoryStream);
                    file.Dispose();
                    imageAsBytes = memoryStream.ToArray();
                    memoryStream.Position = 0;

                }
                App.OwnProfileImage = imageAsBytes;



                var bs64 = Convert.ToBase64String(imageAsBytes);
                var resjs = App.Api.upload_photo(bs64);
                var res = JsonConvert.DeserializeObject<api.Users>(resjs);
                if (res.Loaded.Contains("ok"))
                {
                    hack1RUTECHfreeUI.App.Current.MainPage.Navigation.PushModalAsync(new ChatProfilePage());
                    return;
                }
                Application.Current.MainPage.DisplayAlert("Уведомление", resjs, "ОK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        private async void OpenButtonClicked(object obj)
        {
            try
            {

                    hack1RUTECHfreeUI.App.Current.MainPage.Navigation.PushModalAsync(new BottomNavigationPage());
            
    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// Invoked when the available status is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void AvailableStatusClicked(object obj)
        {
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            (obj as Grid).BackgroundColor = (Color)retVal;
            await Task.Delay(100);
            (obj as Grid).BackgroundColor = Color.Transparent;
        }

        /// <summary>
        /// Invoked when the notification option is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void NotificationOptionClicked(object obj)
        {
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            (obj as Grid).BackgroundColor = (Color)retVal;
            await Task.Delay(100);
            (obj as Grid).BackgroundColor = Color.Transparent;
        }

        #endregion
    }
}
