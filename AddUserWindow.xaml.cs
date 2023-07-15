using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop01
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow(AddUserVM vm)

        {
            InitializeComponent();
            DataContext = vm;
            vm.CloseAction = () => Close();
        }
        private void btnResize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }


        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private bool isDragging = false;
        private Point dragOffset;

        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            dragOffset = e.GetPosition(this);
            this.CaptureMouse();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPosition = e.GetPosition(this);
                double left = currentPosition.X - dragOffset.X + this.Left;
                double top = currentPosition.Y - dragOffset.Y + this.Top;
                this.Left = left;
                this.Top = top;
            }
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            this.ReleaseMouseCapture();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double windowHeight = ActualHeight;
            double windowTop = (SystemParameters.PrimaryScreenHeight - windowHeight) / 2;
            Left = screenWidth - ActualWidth;
            Top = windowTop;
        }


    }
}
