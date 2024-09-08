using Microsoft.Maui.Controls;

namespace VirtualAiSleepMonitor.Resources
{
    public static class ResourceClass
    {
        public static ResourceDictionary ThemeResources()
        {
            return new ResourceDictionary
            {
                // Define the background color, text color, font size, etc.
                { "BackgroundColor", Color.FromHex("#333333") },  // Light background color
                { "TextColor", Color.FromHex("#333333") },        // Dark text color
                { "ButtonFontSize", 18.0 },                       // Font size for buttons
                { "ButtonTextColor", Color.FromRgb(32,32,32) },               // Button text color
                { "ButtonBackgroundColor", Color.FromHex("#2196F3") }  // Button background color
            };
        }
    }
}
