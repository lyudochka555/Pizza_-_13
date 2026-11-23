using System;
using System.Windows;
using Pizza_Данилова.Layouts;

namespace Pizza_Данилова
{
    public partial class MainWindow : Window
    {
        public string localPath;

        public MainWindow()
        {
            InitializeComponent();
            localPath = System.IO.Directory.GetCurrentDirectory();
            OpenPages(pages.main);
        }

        public enum pages
        {
            main
        }

        public void OpenPages(pages _pages)
        {
            if (_pages == pages.main)
            {
                frame.Navigate(new Pizza_Данилова.Layouts.Main());
            }
        }
    }
}