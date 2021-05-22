using FastMoneyBookmaker.ViewModels;
using System.Data.Entity;
using System.Windows;
using FastMoneyBookmaker.View;
using System;
using System.Windows.Input;

namespace FastMoneyBookmaker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookmakerContext Bk { get; set; }
        public MainWindow()
        {
           Bk  = new BookmakerContext();
            Bk.Users.Load();
            Bk.Passports.Load();
            Bk.Contacts.Load();
            Bk.Matches.Load();
            Bk.Bets.Load();
            Bk.Teams.Load();
            InitializeComponent();
            MainViewModel mainView = new MainViewModel(Bk,this);
            this.DataContext = mainView;
        
           
        }
        ~MainWindow()
        {
            Bk.Dispose();
        }

    
    }
}
