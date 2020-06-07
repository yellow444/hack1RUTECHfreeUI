using hack1RUTECHfreeUI.Views.Forms;
using hack1RUTECHfreeUI.Web;

using Newtonsoft.Json;

using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

using System;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace hack1RUTECHfreeUI.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for sign-up page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel : LoginViewModel
    {
        #region Fields
        private string name;
        private string surname;
        private string patronymic;

        private string password;

        private string confirmPassword;
        public ICommand BackToMain { get; private set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SignUpPageViewModel" /> class.
        /// </summary>
        public SignUpPageViewModel()
        {
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            BackToMain = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user in the Sign Up page.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.NotifyPropertyChanged();
            }
        }
        public string SurName
        {
            get
            {
                return this.surname;
            }

            set
            {
                if (this.surname == value)
                {
                    return;
                }

                this.surname = value;
                this.NotifyPropertyChanged();
            }
        }
        public string Patronymic
        {
            get
            {
                return this.patronymic;
            }

            set
            {
                if (this.patronymic == value)
                {
                    return;
                }

                this.patronymic = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password from users in the Sign Up page.
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

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password confirmation from users in the Sign Up page.
        /// </summary>
        public string ConfirmPassword
        {
            get
            {
                return this.confirmPassword;
            }

            set
            {
                if (this.confirmPassword == value)
                {
                    return;
                }

                this.confirmPassword = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Log in button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            hack1RUTECHfreeUI.App.Current.MainPage.Navigation.PushModalAsync(new SimpleLoginPage());
            // Do something
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void SignUpClicked(object obj)
        {
       
            string resjs = "";
            try
            {


                App.Api = new Web.api.Inwike2020(Name, SurName, Patronymic, Email, Password);
                resjs = App.Api.reg();
                var res = JsonConvert.DeserializeObject<api.Users>(resjs);
                if (res.Registered.Contains("ok"))
                {
                    hack1RUTECHfreeUI.App.Current.MainPage.Navigation.PushModalAsync(new SimpleLoginPage());
                    return;
                }
                Application.Current.MainPage.DisplayAlert("Уведомление", resjs, "ОK");
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", resjs, "ОK");
            }
            // Do something
        }


        #endregion
    }
}