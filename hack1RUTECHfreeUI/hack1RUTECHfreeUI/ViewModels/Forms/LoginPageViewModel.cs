using hack1RUTECHfreeUI.Views.Profile;
using hack1RUTECHfreeUI.Web;

using Newtonsoft.Json;

using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using hack1RUTECHfreeUI.Views.Forms;

namespace hack1RUTECHfreeUI.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : LoginViewModel
    {
        #region Fields

        public ICommand BackToPage { get; private set; }
        private string password;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginPageViewModel()
        {
            Email = "ivanov";
            Password = "1111";
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.SocialMediaLoginCommand = new Command(this.SocialLoggedIn);
        }

        #endregion Constructor

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion property

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the social media login button is clicked.
        /// </summary>
        public Command SocialMediaLoginCommand { get; set; }

        #endregion Command

        #region methods

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            string resjs = "";
            try
            {
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                    App.Api = new Web.api.Inwike2020("", "", "", Email, Password);
                resjs = App.Api.aut();
                var res = JsonConvert.DeserializeObject<api.Users>(resjs);
                if (res.Authorized.Contains("true"))
                {
                    hack1RUTECHfreeUI.App.Current.MainPage.Navigation.PushModalAsync(new ChatProfilePage());
                    return;
                }
                Application.Current.MainPage.DisplayAlert("Уведомление", resjs, "ОK");
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ОK");
            }
            // Do something
        }
        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        public async void SignUpClicked(object obj)
        {
            //   hack1RUTECHfreeUI.App.Current.MainPage.Navigation.PushModalAsync(new hack1RUTECHfreeUI.View.CameraPage());
            hack1RUTECHfreeUI.App.Current.MainPage.Navigation.PushModalAsync(new SimpleSignUpPage());

        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void ForgotPasswordClicked(object obj)
        {
            var label = obj as Label;
            label.BackgroundColor = Color.FromHex("#70FFFFFF");
            await Task.Delay(100);
            label.BackgroundColor = Color.Transparent;
        }

        /// <summary>
        /// Invoked when social media login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SocialLoggedIn(object obj)
        {
            var browser = new WebView
            {
                Source = "http://xamarin.com"
            };

            // Do something
        }

        #endregion methods
    }

}