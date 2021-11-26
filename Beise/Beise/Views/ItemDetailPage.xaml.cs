using Beise.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Beise.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}