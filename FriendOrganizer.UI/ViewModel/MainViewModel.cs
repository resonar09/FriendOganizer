using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private readonly IFriendDataService _friendDataService;
        private Friend _selectedFriend;
        private string filterText;
        private CollectionViewSource clientsCollection;

        public MainViewModel(IFriendDataService friendDataService)
        {
            clientsCollection = new CollectionViewSource();
            Friends = new ObservableCollection<Friend>();
            _friendDataService = friendDataService;
        }
        public async Task LoadAsync()
        {
            var friends = await _friendDataService.GetAllAsync();
            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
            clientsCollection.Source = Friends;
            clientsCollection.Filter += usersCollection_Filter;
        }

        public void Load()
        {
            clientsCollection = new CollectionViewSource();
            var friends = _friendDataService.GetAllAsync().Result;
            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
            clientsCollection.Source = Friends;
            clientsCollection.Filter += usersCollection_Filter;
        }

        private void usersCollection_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            Friend friend = e.Item as Friend;
            if (friend.FirstName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        public ObservableCollection<Friend> Friends { get; set; }

        public ICollectionView SourceCollection
        {
            get
            {
                clientsCollection.Source = Friends;
                return this.clientsCollection.View;
            }
        }

        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                filterText = value;
                this.clientsCollection.View.Refresh();
                OnPropertyChanged();
            }
        }

        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
            }
        }


    }
}
