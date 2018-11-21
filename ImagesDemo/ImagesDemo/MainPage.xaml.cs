using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImagesDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IFileService>().DownLoadImages("https://www.xamarin.com/content/images/pages/branding/assets/xamagon.png");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filePath = Path.Combine(documentPath, "Sample/sudhir_1.jpg");
            // Then set this image source to image control
            MyImage.Source = ImageSource.FromFile(filePath);
        }
    }
}
