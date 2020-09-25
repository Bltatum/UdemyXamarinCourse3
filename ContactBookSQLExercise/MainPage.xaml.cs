using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBookSQLExercise.Models;
using ContactBookSQLExercise.Persistance;
using SQLite;
using Xamarin.Forms;

namespace ContactBookSQLExercise
{
    public partial class MainPage : ContentPage

    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Contact> _contacts;
        private bool _isDataLoaded;

        public MainPage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;
            _isDataLoaded = true;

            await LoadData();

            base.OnAppearing();
        }

        private async Task LoadData()
        {
            await _connection.CreateTableAsync<Contact>();

            var contacts = await _connection.Table<Contact>().ToListAsync();

            _contacts = new ObservableCollection<Contact>(contacts);
            contactsListView.ItemsSource = _contacts;
        }



       async void Add_Clicked(System.Object sender, System.EventArgs e)
        {
            var contactPage = new ContactDetailPage(new Contact());
         
            contactPage.ContactAdded += (source, contact) =>
            {
                _contacts.Add(contact);
            };

           await Navigation.PushAsync(contactPage);
        }

        async void Delete_Clicked(System.Object sender, System.EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
                _contacts.Remove(contact);

            await _connection.DeleteAsync(contact);
        }

        async void contacts_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (contactsListView.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;

            contactsListView.SelectedItem = null;

            var contactDetailPage = new ContactDetailPage(selectedContact);
            contactDetailPage.ContactUpdated += (source, contact) =>
            {
                selectedContact.Id = contact.Id;
                selectedContact.FirstName = contact.FirstName;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.IsBlocked = contact.IsBlocked;
            };

            await Navigation.PushAsync(contactDetailPage);

        }
    }
}
