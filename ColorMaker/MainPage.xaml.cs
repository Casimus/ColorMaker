
using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        bool isRandom = false;
        string hexValue = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            if (!isRandom)
            {
                SetColor(color);
            }
        }

        private void SetColor(Color color)
        {
            Debug.WriteLine(color.ToString());
            btnRandomColor.BackgroundColor = color;
            Container.BackgroundColor = color;
            hexValue = color.ToHex();
            lblHex.Text = hexValue;

        }

        private void btnRandomColor_Clicked(object sender, EventArgs e)
        {
            isRandom = true ;
            var random = new Random();
            var color = Color.FromRgb(
                random.Next(256),
                random.Next(256),
                random.Next(256));
            SetColor(color);
            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;
            isRandom = false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = Toast.Make(
                "Color copied", 
                CommunityToolkit.Maui.Core.ToastDuration.Short, 
                12);
            await toast.Show();
        }
    }

}
