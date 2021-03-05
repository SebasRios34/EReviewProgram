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
            extractServiceAccountPassword();
            extractServiceExtAuthEndpoint();
            extractInstallationDirectory();
        }

        string folderPath = InstallationDirectory.PropertiesFile + "\\install-assets\\install.properties";
        string ereviewPath = InstallationDirectory.PropertiesFile + "\\tomcat\\ereview.properties";

        public void editServiceAccountPassword() 
        {
            using (StreamReader readFile = new StreamReader(folderPath))
            {
                string searchLine = readFile.ReadLine();

                if (searchLine.Contains("serviceAccountPassword"))
                {
                    readFile.Close();
                    using (StreamWriter writeFile = new StreamWriter(folderPath))
                    {
                        string value = "serviceAccountPassword=" + txtServiceAccountPassword.Text + "\nserviceExtAuthEndpoint=" + "\ninstallDir=";
                        writeFile.WriteLine(value);
                    }
                }
            };
        }

        public void editServiceExtAuthEndpoint() 
        {
            using (StreamReader readFile = new StreamReader(folderPath))
            {
                int i = 0;

                while (i == 0) 
                {
                    string searchLine = readFile.ReadLine();
                    if (searchLine.Contains("serviceExtAuthEndpoint"))
                    {
                        readFile.Close();
                        i++;
                        using (StreamWriter writeFile = new StreamWriter(folderPath))
                        {
                            string value = "serviceAccountPassword=" + txtServiceAccountPassword.Text + "\nserviceExtAuthEndpoint=" + txtServiceExtAuthEndpoint.Text + "\ninstallDir=" + InstallationDirectory.PropertiesFile;
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

        public void editInstallDir() 
        {
            using (StreamReader readFile = new StreamReader(folderPath))
            {
                int i = 0;

                while (i == 0)
                {
                    string searchLine = readFile.ReadLine();
                    if (searchLine.Contains("installDir"))
                    {
                        readFile.Close();
                        i++;
                        using (StreamWriter writeFile = new StreamWriter(folderPath))
                        {
                            string value = "serviceAccountPassword=" + txtServiceAccountPassword.Text + "\nserviceExtAuthEndpoint=" + txtServiceExtAuthEndpoint.Text + "\ninstallDir=" + InstallationDirectory.PropertiesFile;
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
        
        /*
        public void searchReplace() 
        {
            using (StreamReader readFile = new StreamReader(folderPath))
            {
                int i = 0;

                while (i == 0) 
                {
                    string searchLine = readFile.ReadLine();
                    if (searchLine.Contains("serviceAccountPassword"))
                    {
                        readFile.Close();
                        i++;
                        using (StreamWriter writeFile = new StreamWriter(ereviewPath)) 
                        {

                        }
                    }
                }
            }
        }
        */

        public void extractServiceAccountPassword() 
        {
            string toSearch = @"serviceAccountPassword";
            string[] lines = File.ReadAllLines(folderPath);
            foreach (string line in lines)
            {
                if (line.Contains(toSearch))
                {
                    string serviceAccountPassword = line.Remove(0, 23);
                    txtServiceAccountPassword.Text = serviceAccountPassword;
                }
            }
        }

        public void extractServiceExtAuthEndpoint() 
        {
            string toSearch = @"serviceExtAuthEndpoint";
            string[] lines = File.ReadAllLines(folderPath);
            foreach (string line in lines)
            {
                if (line.Contains(toSearch))
                {
                    string serviceExtAuthEndpoint = line.Remove(0, 23);
                    txtServiceExtAuthEndpoint.Text = serviceExtAuthEndpoint;
                }
            }
        }

        public void extractInstallationDirectory()
        {
            string toSearch = @"installDir";
            string[] lines = File.ReadAllLines(folderPath);
            foreach (string line in lines)
            {
                if (line.Contains(toSearch))
                {
                    string installDir = line.Remove(0, 11);
                    txtInstallDir.Text = InstallationDirectory.PropertiesFile;
                }
            }
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
                editInstallDir();
            }

            //ServicesInstalled page = new ServicesInstalled();
            //page.Show();
            //this.Close();
        }
    }
}
