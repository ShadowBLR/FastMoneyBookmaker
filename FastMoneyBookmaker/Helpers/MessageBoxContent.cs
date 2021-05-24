using FastMoneyBookmaker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FastMoneyBookmaker.Helpers
{
    public class MessageBoxContent
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public BitmapImage Bitmap { get; set; }
        public ActionResult ActionResult { get; set; }
        public SolidColorBrush Color { get; set; }
        public MessageBoxContent(string key,ActionResult res)
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (App.Language.Name)
            {
                case "ru-RU":
                    dict.Source = new Uri(String.Format("Resources/Languages/Lang.{0}.xaml", App.Language.Name), UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("Resources/Languages/Lang.xaml", UriKind.Relative);
                    break;
            }
            switch (res)
            {
                case ActionResult.Error:
                    {
                        Title = (string)dict["Error"];
                        Color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ed5353"));


                        Bitmap = new BitmapImage();
                        Bitmap.BeginInit();
                        Bitmap.UriSource = new Uri(@"C:/Users/User/source/repos/FastMoneyBookmaker/FastMoneyBookmaker/Resources/Icons/error.png", UriKind.Absolute);
                        Bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        Bitmap.EndInit();
                        break;
                    }
                case ActionResult.Succes:
                    {
                        Title = (string)dict["Success"];
                        Color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#56E39F"));


                        Bitmap = new BitmapImage();
                        Bitmap.BeginInit();
                        Bitmap.UriSource = new Uri(@"C:/Users/User/source/repos/FastMoneyBookmaker/FastMoneyBookmaker/Resources/Icons/success.png", UriKind.Absolute);
                        Bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        Bitmap.EndInit();
                        break;
                    }
               
            }
            Text = (string)dict[key];
        }
    }
}
