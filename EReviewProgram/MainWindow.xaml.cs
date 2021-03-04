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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EReviewProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fillTextBox();
        }

        public void fillTextBox() 
        {
            //start index in 0 to read from the beginning
            int index = 0;

            //extract content from txt file by adding the specific path of the local machine
            var lines = File.ReadAllLines(@"C:\Users\sebas\Desktop\ereviewApp\EndUserAgreemenLicenseTest.txt");

            //start reading line by line and displays text into the textbox.
            if (index < lines.Length)
                txtLicenseAgreements.Text = lines[index++];
        }

        private void cbxAccept_Checked(object sender, RoutedEventArgs e)
        {
            if (cbxAccept.IsChecked == true) 
            {
                btnNext.IsEnabled = true;
            }

            if (cbxAccept.IsChecked == false) 
            {
                btnNext.IsEnabled = false;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            InstallationDirectory page = new InstallationDirectory();
            page.Show();
            this.Close();
        }
    }
}
