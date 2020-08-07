using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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

using WpfUI.Classes;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneNumberTextBox.Text

            };
           

            //SQLiteConnection connection = new SQLiteConnection(databasePath);
            //connection.CreateTable<Contact>(); // If the table is already exists, it will not created again
            //connection.Insert(contact);
            ////connection.Close(); // is not the best way to close connection

            // Better way to close connection is using "using" statement
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
          
            } // will dispose the connection object  and close the connection

            // close NewContactWindow
            this.Close();

        }
    }
}
