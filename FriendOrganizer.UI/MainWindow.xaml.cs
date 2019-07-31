using FriendOrganizer.UI.ViewModel;
using System.Windows;
using System;

namespace FriendOrganizer.UI
{

    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            MainWindow_Loaded();
            //Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded()
        {
            _viewModel.Load();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();

        }


    }
}
