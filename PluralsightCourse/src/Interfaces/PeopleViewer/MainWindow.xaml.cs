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
using PeopleLibrary;

namespace PeopleViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PeopleLibrary.PeopleRepository repository;

        public MainWindow()
        {
            InitializeComponent();
            repository = new PeopleRepository();
        }

        private void GetPeopleConcrete_OnClick(object sender, RoutedEventArgs e)
        {
            ClearPeopleList();

            string[] peopleList;
            peopleList = repository.GetPeopleList();
            // this brakes
            //peopleList = repository.GetPeopleListNew();
            foreach (var person in peopleList)
            {
                this.PeopleList.Items.Add(person);
            }
        }

        private void GetPeopleInterface_OnClick(object sender, RoutedEventArgs e)
        {
            ClearPeopleList();

            //coding to interface
            IEnumerable<string> peopleList;
            peopleList = repository.GetPeopleList();
            peopleList = repository.GetPeopleListNew();
            foreach (var person in peopleList)
            {
                this.PeopleList.Items.Add("I " + person);
            }
        }

        private void ClearList_OnClick(object sender, RoutedEventArgs e)
        {
            ClearPeopleList();
        }

        private void ClearPeopleList()
        {
            this.PeopleList.Items.Clear();
        }
    }
}
