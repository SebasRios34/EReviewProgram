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
using System.Windows.Shapes;

namespace EReviewProgram
{
    /// <summary>
    /// Interaction logic for ConfigurationValues.xaml
    /// </summary>
    public partial class ConfigurationValues : Window
    {
        public ConfigurationValues()
        {
            InitializeComponent();
            extractFields();
        }

        public void editServiceAccountPassword() 
        {
            //unable to retreat string PropertiesFile from InstallationDirectory class
            //InstallationDirectory installation = new InstallationDirectory();

            using (StreamReader readFile = new StreamReader(@"C:\\Users\\sebas\\Desktop\\TEST\\install-assets\\install.properties"))
            {
                string searchLine = readFile.ReadLine();

                if (searchLine.Contains("serviceAccountPassword"))
                {
                    readFile.Close();
                    using (StreamWriter writeFile = new StreamWriter(@"C:\\Users\\sebas\\Desktop\\TEST\\install-assets\\install.properties"))
                    {
                        string value = "serviceAccountPassword=" + txtServiceAccountPassword.Text + "\nserviceExtAuthEndpoint=";
                        writeFile.WriteLine(value);
                    }
                }
            };
        }

        public void editServiceExtAuthEndpoint() 
        {
            using (StreamReader readFile = new StreamReader(@"C:\\Users\\sebas\\Desktop\\TEST\\install-assets\\install.properties"))
            {
                int i = 0;

                while (i == 0) 
                {
                    string searchLine = readFile.ReadLine();
                    if (searchLine.Contains("serviceExtAuthEndpoint"))
                    {
                        readFile.Close();
                        i++;
                        using (StreamWriter writeFile = new StreamWriter(@"C:\\Users\\sebas\\Desktop\\TEST\\install-assets\\install.properties"))
                        {
                            string value = "serviceAccountPassword=" + txtServiceAccountPassword.Text + "\nserviceExtAuthEndpoint=" + txtServiceExtAuthEndpoint.Text;
                            writeFile.WriteLine(value);
                        }
                    }
                    else 
                    {
                        i = 0;
                    }
                }
            };
        }

        public void extractFields() 
        {
            string txtFile = File.ReadAllText(@"C:\\Users\\sebas\\Desktop\\TEST\\install-assets\\install.properties");
            int firstPosition = txtFile.IndexOf("\n");

            string extractServiceAccountPassword = txtFile.Substring(0, firstPosition);
            string extractServiceExtAuthEndpoint = txtFile.Substring(firstPosition + 1);

            string serviceAccountPassword = extractServiceAccountPassword.Remove(0, 23);
            string serviceExtAuthEndpoint = extractServiceExtAuthEndpoint.Remove(0, 23);

            txtServiceAccountPassword.Text = serviceAccountPassword;
            txtServiceExtAuthEndpoint.Text = serviceExtAuthEndpoint;

            //MessageBox.Show("Password: " + serviceAccountPassword + "\nAuth Endpoint: " + serviceExtAuthEndpoint);
        }

        private void btnConfigure_Click(object sender, RoutedEventArgs e)
        {

            if (txtServiceAccountPassword.Text == "" || txtServiceAccountPassword.Text == null)
            {
                MessageBox.Show("Please select a value for Service Account Password");
                txtServiceAccountPassword.Focus();
            }
            else if (txtServiceExtAuthEndpoint.Text == "" || txtServiceExtAuthEndpoint.Text == null)
            {
                MessageBox.Show("Please select a value for Service Authentication Endpoint");
                txtServiceExtAuthEndpoint.Focus();
            }
            else 
            {
                editServiceAccountPassword();
                editServiceExtAuthEndpoint();
            }

            //ServicesInstalled page = new ServicesInstalled();
            //page.Show();
            //this.Close();
        }
    }
}
