using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Desktop01
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser=null;



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void messeag()
        {
            MessageBox.Show($"The GPA value of {selectedUser.FirstName} should fall within the range of 0 to 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName == null)
            {
                return;
            }
            else
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");
            }
            else
            {
                MessageBox.Show("Please ensure that a student is selected before proceeding with the deletion.", "Error");
            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                var window = new AddUserWindow(vm);

                window.ShowDialog();


                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        public  MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new User(23, "Ranga", "Dananjaya", "27/09/1999",image1,3.26));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new User(27, "Yasasha", "Nimesh", "27/09/1995",image2,3.45));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new User(22, "Sandun", "Lakshan", "24/1/2000",image3,2.84));
            BitmapImage image4= new BitmapImage(new Uri("/Model/Images/5.png", UriKind.Relative));
            users.Add(new User(21, "Nimesh", "Apa", "12/1/2001", image4,4.00));
            BitmapImage image5 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(21, "Hansa", "Dana", "22/06/2001", image5, 3.52));
        }
    }
}
