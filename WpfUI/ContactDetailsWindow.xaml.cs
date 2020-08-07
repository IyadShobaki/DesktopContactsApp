using SQLite;
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
using WpfUI.Classes;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact _contact;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            _contact = contact;

            nameTextBox.Text = _contact.Name;
            emailTextBox.Text = _contact.Phone;
            phoneNumberTextBox.Text = _contact.Email;
        
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            _contact.Name = nameTextBox.Text;
            _contact.Email = emailTextBox.Text;
            _contact.Phone = phoneNumberTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(_contact);

            }

            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(_contact);

            } 

            this.Close();
        }

    }
}
