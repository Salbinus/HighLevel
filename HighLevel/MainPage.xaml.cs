using Microsoft.Maui.Controls;
using HighLevel;

namespace HighLevel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new FormViewModel();
        }
    }
}