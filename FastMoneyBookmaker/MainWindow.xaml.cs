using FastMoneyBookmaker.ViewModels;
using System.Windows;

namespace FastMoneyBookmaker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainView = new MainViewModel();
            this.DataContext = mainView;
        }
    }
}
