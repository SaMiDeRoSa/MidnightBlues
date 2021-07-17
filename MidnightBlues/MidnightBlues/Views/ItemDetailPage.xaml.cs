using MidnightBlues.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MidnightBlues.Views
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