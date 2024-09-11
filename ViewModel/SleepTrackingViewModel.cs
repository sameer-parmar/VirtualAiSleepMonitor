using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Permissions = Xamarin.Essentials.Permissions;
using PermissionStatus = Xamarin.Essentials.PermissionStatus;

namespace VirtualAiSleepMonitor.ViewModel
{
    public class SleepTrackingViewModel : BaseViewModel
    {
        private bool _isTracking;
        private DateTime _startTime;
        private System.Timers.Timer _trackingTimer;
        private string _sleepDurationText;
        private string _disturbanceInfo;
        private List<double> _soundLevels;
        private const double DisturbanceThreshold = 70.0;

        // Property to expose tracking status to the UI
        public bool IsTracking
        {
            get => _isTracking;
            private set
            {
                _isTracking = value;
                OnPropertyChanged(nameof(IsTracking));
            }
        }

        // Property to expose sleep duration to the UI
        public string SleepDurationText
        {
            get => _sleepDurationText;
            private set
            {
                _sleepDurationText = value;
                OnPropertyChanged(nameof(SleepDurationText));
            }
        }

        // Property to expose disturbance information to the UI
        public string DisturbanceInfo
        {
            get => _disturbanceInfo;
            private set
            {
                _disturbanceInfo = value;
                OnPropertyChanged(nameof(DisturbanceInfo));
            }
        }

        public Command StartTrackingCommand { get; }
        public Command StopTrackingCommand { get; }

        public SleepTrackingViewModel()
        {
            StartTrackingCommand = new Command(async () => await StartTrackingAsync());
            StopTrackingCommand = new Command(StopTracking);
            _soundLevels = new List<double>();
        }

        // Method to start tracking sleep
        public async Task StartTrackingAsync()
        {
            _soundLevels.Clear();

            // Request microphone permission
            var permissionStatus = await RequestMicrophonePermissionAsync();
            if (permissionStatus != PermissionStatus.Granted)
            {
                await Application.Current.MainPage.DisplayAlert("Permission Denied", "Microphone access is needed to track sleep.", "OK");
                return;
            }

            IsTracking = true;
            _startTime = DateTime.Now;

            _trackingTimer = new System.Timers.Timer(1000); // Update every second
            _trackingTimer.Elapsed += OnTrackingElapsed;
            _trackingTimer.Start();
        }

        // Method to stop tracking sleep
        public void StopTracking()
        {
            if (IsTracking)
            {
                IsTracking = false;
                _trackingTimer?.Stop();
                _trackingTimer?.Dispose();

                var duration = DateTime.Now - _startTime;
                SleepDurationText = $"Sleep Duration: {duration.Hours} hours {duration.Minutes} minutes {duration.Seconds} seconds";

                //DisturbanceInfo = CalculateDisturbances();
            }
        }

        // Request microphone permission
        private async Task<PermissionStatus> RequestMicrophonePermissionAsync()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Microphone>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Microphone>();
            }
            return status;
        }

        // Timer elapsed event to update sleep duration
        private void OnTrackingElapsed(object sender, ElapsedEventArgs e)
        {
            var duration = DateTime.Now - _startTime;
            SleepDurationText = $"Sleep Duration: {duration.Hours} hours {duration.Minutes} minutes {duration.Seconds} seconds";
        }

        // Stub method for sound level processing (to replace platform-specific code)
        private async Task<double> GetCurrentSoundLevelAsync()
        {
            // Simulated sound level processing
            await Task.Delay(2000); // Simulate a delay
            return new Random().NextDouble() * 100; // Return a random sound level between 0-100 dB
        }

        // Calculate disturbances based on sound levels
        private string CalculateDisturbances()
        {
            var averageSoundLevel = GetCurrentSoundLevelAsync().Result;

            if (averageSoundLevel > DisturbanceThreshold)
            {
                return $"Disturbance detected: High noise level ({averageSoundLevel:F2} dB) in the last 5 minutes.";
            }
            else
            {
                return "No significant disturbances detected.";
            }
        }
    }
}
