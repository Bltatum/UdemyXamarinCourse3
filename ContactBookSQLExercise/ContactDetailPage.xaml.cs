using System;
using System.Collections.Generic;
using ContactBookSQLExercise.Models;
using ContactBookSQLExercise.Persistance;
using SQLite;
using Xamarin.Forms;

namespace ContactBookSQLExercise
{
    public partial class ContactDetailPage : ContentPage
    {
        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;

        private SQLiteAsyncConnection _connection;

        public ContactDetailPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            BindingContext = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked
            };
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            var contact = BindingContext as Contact;

            if (string.IsNullOrWhiteSpace(contact.FullName))
            {
                await DisplayAlert("Error", "Please enter a name.", "Ok");
                return;
            }

            if (contact.Id == 0)
            {
                await _connection.InsertAsync(contact);

                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                await _connection.UpdateAsync(contact);
                ContactUpdated?.Invoke(this, contact);
            }

            await Navigation.PopAsync();
        }
    }
}
