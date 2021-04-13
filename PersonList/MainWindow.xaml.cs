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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace PersonList
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Name.DataContext = Person.People;
            CreatePeople();
        }
        private void Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person p = ((KeyValuePair<string, Person>)Name.SelectedItem).Value;
            DataContext = p;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Name.SelectedIndex = 0;
        }
        public static void CreatePeople()
        {
                Person.People["Jan"] = new Person
                {
                    Name = "Jan",
                    Surname = "Polívka",
                    DateOfBirth = new DateTime(1998, 10, 28),
                    IdentityNumber = "981028/5809"
                };

                Person.People["Petr"] = new Person
                {
                    Name = "Petr",
                    Surname = "Proske",
                    DateOfBirth = new DateTime(2002, 1, 17),
                    IdentityNumber = "020117/1774"
                };

                Person.People["Luboš"] = new Person
                {
                    Name = "Luboš",
                    Surname = "Kajínek",
                    DateOfBirth = new DateTime(1997, 3, 1),
                    IdentityNumber = "970301/4712"
                };

                Person.People["Jakub"] = new Person
                {
                    Name = "Jakub",
                    Surname = "Kron",
                    DateOfBirth = new DateTime(2014, 9, 6),
                    IdentityNumber = "170906/9845"
                };

                Person.People["Martin"] = new Person
                {
                    Name = "Martin",
                    Surname = "Macek",
                    DateOfBirth = new DateTime(2008, 12, 13),
                    IdentityNumber = "081213/0045"
                };


        }
    }
    class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static Dictionary<string, Person> People = new Dictionary<string, Person>();

        private string name;
        public string Name
        {
            get => name;
            set { name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("State")); }
        }

        private string surname;
        public string Surname
        {
            get => surname;
            set { surname = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Established")); }
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set { dateOfBirth = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Address")); }
        }

        private string identityNumber;
        public string IdentityNumber
        {
            get => identityNumber;
            set { identityNumber = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SuccessRate")); }
        }
    }
}
