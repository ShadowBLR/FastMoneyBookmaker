using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FastMoneyBookmaker.ViewModels
{
    class MyProfileVM:ViewModel,IPageVIewModel
    {
       public FullUserViewModel UserVM { get; set; }
        private Uri uri;
        private Uri oldUri;
        private BitmapFrame imagePath;
        public BitmapFrame ImagePath
        {
            get => imagePath;
            set => Set(ref imagePath, value);
        }
 
        private RelayCommand loadPictureCommand;
        public ICommand LoadPictureCommand
        {
            get
            {
                if (loadPictureCommand == null)
                {
                    loadPictureCommand = new RelayCommand(
                    (obj)=>LoadPicture(ref obj)
                    ,(obj)=>true
                    );
                }
                return loadPictureCommand;
            }
        }
        private void LoadPicture(ref object obj)
        {
            string oldPath="";
            if (ImagePath != null)
            {
                oldPath = ImagePath.Decoder.ToString();
            }
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = "jpg",
                Filter =
                "JPG files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp|PNG files (*.png)|*.png"
            };
            if (openFileDialog.ShowDialog() == true)
            {
              if(oldUri!=null)
                {
                    oldUri = uri;
                }
                
                string path = @"../../FTP/Images/"+openFileDialog.SafeFileName + Path.GetExtension(openFileDialog.FileName);
                File.Copy(openFileDialog.FileName, path);
                uri = new Uri(path, UriKind.Relative);
                ImagePath = BitmapFrame.Create(uri,BitmapCreateOptions.None,BitmapCacheOption.OnLoad);
                //ImagePath  = BitmapFrame.Create(new Uri(path,UriKind.Relative));
                if(!string.IsNullOrEmpty(oldPath))
                {
                    
                    File.Delete(oldPath);
                }
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    
    }
}
