using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.Models;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media.Imaging;

namespace FastMoneyBookmaker.ViewModels
{
    class MyProfileViewMode:ViewModel,IPageVIewModel
    {
        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set => Set(ref currentUser, value);
        }
        public BookmakerContext Context { get; set; }
        private BitmapFrame imagePath;
        public BitmapFrame ImagePath
        {
            get => imagePath;
            set => Set(ref imagePath, value);
        }
        #region Constructor
        public MyProfileViewMode(BookmakerContext bookmaker,User currentUser)
        {
            CurrentUser = currentUser;
            
            Context = bookmaker;
            if (!String.IsNullOrEmpty(CurrentUser.Avatar))
            {
                ImagePath = BitmapFrame.Create
                      (new Uri(
                              CurrentUser.Avatar, UriKind.Relative
                              ), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
        #endregion
        #region LoadPictureCommand
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
            if (obj is string)
            {
                oldPath = (string)obj;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = "jpg",
                Filter =
                "JPG files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp|PNG files (*.png)|*.png"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string path = @"../../FTP/Images/"+CurrentUser.Nickname + Path.GetExtension(openFileDialog.FileName);
                if (!string.IsNullOrEmpty(oldPath))
                {
                    File.Delete(oldPath);
                }
                File.Copy(openFileDialog.FileName, path);   
                CurrentUser.Avatar = path;
                ImagePath = BitmapFrame.Create
                    (new Uri(
                            path, UriKind.Relative
                            ), BitmapCreateOptions.None,BitmapCacheOption.OnLoad);
                var usr = Context.Users
                    .Where(us => us.Nickname == CurrentUser.Nickname)
                    .FirstOrDefault();
                usr.Avatar = CurrentUser.Avatar;
                Context.SaveChanges();
            }
            else
            {
                System.Windows.MessageBox.Show("ERROR");
            }
        }
        #endregion

    }
}
