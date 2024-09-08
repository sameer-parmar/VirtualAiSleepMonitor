namespace VirtualAiSleepMonitor.View
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            DisplayAlert("Start Tracking", "Further we will be linking all the stuff here(Dynamically)", "GOT IT MAN");
        }
        private void View_History(object sender, EventArgs e)
        {
            DisplayAlert("History", "You can further add more functionality here", "GOT IT MAN");

        }
    }

}
