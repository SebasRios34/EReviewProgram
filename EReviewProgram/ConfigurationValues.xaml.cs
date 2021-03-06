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

        private static string mainServiceAccountPassword, mainServiceExtAuthEndpoint, mainInstallationDirectory;

        public static string MainServiceAccountPassword 
        {
            get { return mainServiceAccountPassword; }
        }

        public static string MainServiceExtAuthEndpoint 
        {
            get { return mainServiceExtAuthEndpoint; }
        }

        public static string MainInstallationDirectory 
        {
            get { return mainInstallationDirectory; }
        }

        string meantimeFolderPath = @"C:\\ereview\\install-assets\\install.properties";
        string meantimeEreviewPath = @"C:\\ereview\\install-assets\\properties\\ereview.properties";
        string folderPath = InstallationDirectory.PropertiesFile + "\\install-assets\\install.properties";
        string ereviewPath = InstallationDirectory.PropertiesFile + "\\tomcat\\ereview.properties";

        public void editServiceAccountPassword() 
        {
            //change meantimeFolderPath for folderPath after done testing
            using (StreamReader readFile = new StreamReader(meantimeFolderPath))
            {
                string searchLine = readFile.ReadLine();

                if (searchLine.Contains("serviceAccountPassword"))
                {
                    readFile.Close();
                    using (StreamWriter writeFile = new StreamWriter(meantimeFolderPath))
                    {
                        string value = "serviceAccountPassword=" + txtServiceAccountPassword.Text + "\nserviceExtAuthEndpoint=" + "\ninstallDir=";
                        writeFile.WriteLine(value);
                    }
                }
            };
        }

        public void editServiceExtAuthEndpoint() 
        {
            //change meantimeFolderPath for folderPath after done testing
            using (StreamReader readFile = new StreamReader(meantimeFolderPath))
            {
                int i = 0;

                while (i == 0) 
                {
                    string searchLine = readFile.ReadLine();
                    if (searchLine.Contains("serviceExtAuthEndpoint"))
                    {
                        readFile.Close();
                        i++;
                        using (StreamWriter writeFile = new StreamWriter(meantimeFolderPath))
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
            //change meantimeFolderPath for folderPath after done testing
            using (StreamReader readFile = new StreamReader(meantimeFolderPath))
            {
                int i = 0;

                while (i == 0)
                {
                    string searchLine = readFile.ReadLine();
                    if (searchLine.Contains("installDir"))
                    {
                        readFile.Close();
                        i++;
                        using (StreamWriter writeFile = new StreamWriter(meantimeFolderPath))
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

        public void searchReplace(string newText, string variableToChange, string folderPath, int lineToEdit) 
        {
            string[] arrayLine = File.ReadAllLines(folderPath);
            string text = variableToChange + newText;
            arrayLine[lineToEdit] = text;
            File.WriteAllLines(folderPath, arrayLine);
        }

        public void extractServiceAccountPassword() 
        {
            //change meantimeFolderPath for folderPath after done testing
            string toSearch = @"serviceAccountPassword";
            string[] lines = File.ReadAllLines(meantimeFolderPath);
            foreach (string line in lines)
            {
                if (line.Contains(toSearch))
                {
                    string serviceAccountPassword = line.Remove(0, 23);
                    txtServiceAccountPassword.Text = serviceAccountPassword;
                    //setting string to global string
                    mainServiceAccountPassword = serviceAccountPassword;
                }
            }
        }

        public void extractServiceExtAuthEndpoint() 
        {
            //change meantimeFolderPath for folderPath after done testing
            string toSearch = @"serviceExtAuthEndpoint";
            string[] lines = File.ReadAllLines(meantimeFolderPath);
            foreach (string line in lines)
            {
                if (line.Contains(toSearch))
                {
                    string serviceExtAuthEndpoint = line.Remove(0, 23);
                    txtServiceExtAuthEndpoint.Text = serviceExtAuthEndpoint;
                    //setting string to global variable
                    mainServiceExtAuthEndpoint = serviceExtAuthEndpoint;
                }
            }
        }

        public void extractInstallationDirectory()
        {
            //change meantimeFolderPath for folderPath after done testing
            string toSearch = @"installDir";
            string[] lines = File.ReadAllLines(meantimeFolderPath);
            foreach (string line in lines)
            {
                if (line.Contains(toSearch))
                {
                    string installDir = line.Remove(0, 11);
                    txtInstallDir.Text = installDir;
                    //setting string to global variable
                    mainInstallationDirectory = installDir;
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

                searchReplace(mainServiceAccountPassword, "serviceAccountPassword=", meantimeEreviewPath, 7);
            }

            //ServicesInstalled page = new ServicesInstalled();
            //page.Show();
            //this.Close();
        }
    }
}
