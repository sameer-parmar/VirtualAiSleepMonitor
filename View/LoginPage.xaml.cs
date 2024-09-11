using Microsoft.Maui.Controls;
using VirtualAiSleepMonitor.ViewModel;

namespace VirtualAiSleepMonitor.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
