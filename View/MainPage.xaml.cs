using Microsoft.Maui.Controls;
using VirtualAiSleepMonitor.ViewModel;

namespace VirtualAiSleepMonitor.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new SleepTrackingViewModel();
        }
    }
}
