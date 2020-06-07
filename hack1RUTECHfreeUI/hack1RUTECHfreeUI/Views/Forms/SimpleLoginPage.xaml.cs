using hack1RUTECHfreeUI.ViewModels.Forms;

using System.Windows.Input;

using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace hack1RUTECHfreeUI.Views.Forms
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleLoginPage
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLoginPage" /> class.
        /// </summary>
        public SimpleLoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }

    }
}