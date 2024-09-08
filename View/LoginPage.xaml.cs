using Microsoft.Maui.Controls;
using VirtualAiSleepMonitor.ViewModels;

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
