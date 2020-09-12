using Anju_TestApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace Anju_TestApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            webViewMain.On<Windows>().SetIsJavaScriptAlertEnabled(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadHtmlPage();
        }

        void loadHtmlPage()
        {
            var webViewSource = new UrlWebViewSource();

            string localPath = DependencyService.Get<IBaseFilePath>().GetFilePath();
            webViewSource.Url = Path.Combine(localPath, "color.html"); 

            webViewMain.Source = webViewSource.Url;
        }

        private void webViewMain_Navigating(object sender, WebNavigatingEventArgs e)
        {
            string paramName = e.Url.Substring(e.Url.LastIndexOf("/"));

            if (paramName.Substring(0, 1) == "/")
            {
                paramName = paramName.Substring(1, paramName.Length - 1);
            }

            if (paramName == "ChangeColor")
            {
                e.Cancel = true;
                lblColor.TextColor = GeteRandomColor();
            }
        }

        private Color GeteRandomColor()
        {
            Random random = new Random();
            return Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
        }

    }
}
