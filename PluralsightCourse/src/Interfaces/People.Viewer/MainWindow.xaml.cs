using System.Configuration;
using System.Windows;
using People.Library;
using People.Core;


namespace PeopleViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SimplePeopleRepository concreteRepository;

        public MainWindow()
        {
            InitializeComponent();
            concreteRepository = new SimplePeopleRepository();
        }

        #region Form Action Handers

        private void GetPeopleConcrete_OnClick(object sender, RoutedEventArgs e)
        {
            ClearPeopleList();

            string[] peopleList;
            peopleList = concreteRepository.GetPeopleArray();
            // this brakes
            //peopleList = repository.GetPeopleListNew();
            foreach (var person in peopleList)
            {
                this.PeopleList.Items.Add(person);
            }
        }

        private void GetPeopleSimpleRepo_OnClick(object sender, RoutedEventArgs e)
        {
            ClearPeopleList();
            //coding to interface
            GetPeopleFromRepo(RepositoryType.SimpleRepo);
        }

        private void GetPeopleWcfRepo_OnClick(object sender, RoutedEventArgs e)
        {
            ClearPeopleList();
            GetPeopleFromRepo(RepositoryType.WcfRepo);
        }

        private void ClearList_OnClick(object sender, RoutedEventArgs e)
        {
            ClearPeopleList();
        }

        #endregion

        private void GetPeopleFromRepo(RepositoryType type)
        {
            var repo = PeopleRepositoryFactory.GetPeopleRepository(type);

            foreach (var person in repo.GetPeopleList())
            {
                this.PeopleList.Items.Add(person);
            }
        }

        private void GetPeopleFromDynamicallyLoadedRepo()
        {
            var typeFromConfig = ConfigurationManager.AppSettings["RepositoryType"];
            var repo = PeopleRepositoryFactory.GetPeopleRepositoryDynamically(typeFromConfig);

            foreach (var person in repo.GetPeopleList())
            {
                this.PeopleList.Items.Add(person);
            }

        }

        private void ClearPeopleList()
        {
            this.PeopleList.Items.Clear();
        }

        private void GetPeopleCsvDynamicRepo_OnClick(object sender, RoutedEventArgs e)
        {
            GetPeopleFromDynamicallyLoadedRepo();
        }
    }
}
