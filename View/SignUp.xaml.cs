using VirtualAiSleepMonitor.ViewModel;

namespace VirtualAiSleepMonitor.View;

public partial class SignUp : ContentPage
{
	public SignUp()
	{
		InitializeComponent();
		BindingContext = new SignupViewModel();
	}
}