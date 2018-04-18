using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using People.Core;

namespace People.LayeredViewer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IPeopleRepository _repository;
        private IEnumerable<string> _people;

        public IEnumerable<string> People
        {
            get { return _people; }
            set
            {
                _people = value;
                RaisePropertyChanged("People");
            }
        }

        public MainViewModel()
        {
            var repositoryType = ConfigurationManager.AppSettings["RepositoryType"];
            _repository = PeopleRepositoryFactory.GetPeopleRepositoryDynamically(repositoryType);
        }

        public void FetchData()
        {
            People = _repository.GetPeopleList();
        }

        public void ClearData()
        {
            People = new List<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
