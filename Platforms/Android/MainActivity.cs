using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel; // For permissions handling

namespace VirtualAiSleepMonitor
{
    [Activity(
        Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density
    )]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // No need to manually initialize MAUI here; it's handled automatically
            // Initialize MAUI if needed

            // Request microphone permission
            RequestMicrophonePermission();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            // Forward the permissions result to MAUI
            Microsoft.Maui.ApplicationModel.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private async void RequestMicrophonePermission()
        {
            // Use Microsoft.Maui.ApplicationModel for permissions
            var status = await Permissions.RequestAsync<Permissions.Microphone>();
            if (status != PermissionStatus.Granted)
            {
                // Handle the case when permission is denied
                Android.Widget.Toast.MakeText(this, "Microphone permission is required for recording.", Android.Widget.ToastLength.Long).Show();
            }
        }
    }
}
