using hack1RUTECHfreeUI.DataService;

using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace hack1RUTECHfreeUI.Views.Navigation
{
    /// <summary>
    /// Page to show photo album
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbumPage
    {
        public AlbumPage()
        {
            InitializeComponent();
            this.BindingContext = AlbumDataService.Instance.AlbumViewModel;
        }
    }
}