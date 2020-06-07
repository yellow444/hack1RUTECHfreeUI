using hack1RUTECHfreeUI.DataService;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace hack1RUTECHfreeUI.Views.Navigation
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotosPage : ContentPage
    {
        public PhotosPage()
        {
            InitializeComponent();

            this.BindingContext = PhotosDataService.Instance.PhotosViewModel;
        }
    }
}