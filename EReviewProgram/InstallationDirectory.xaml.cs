using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
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
    /// Interaction logic for InstallationDirectory.xaml
    /// </summary>
    public partial class InstallationDirectory : Window
    {

        private static string propertiesFile;
        public static string PropertiesFile
        {
            get { return propertiesFile; }
        }


        public InstallationDirectory()
        {
            InitializeComponent();
        }

        //unzipping of the file
        public static void unZip(string zipFile, string folderPath)
        {
            if (!File.Exists(zipFile))
                throw new FileNotFoundException();

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            Shell32.Shell objShell = new Shell32.Shell();
            Shell32.Folder destinationFolder = objShell.NameSpace(folderPath);
            Shell32.Folder sourceFile = objShell.NameSpace(zipFile);

            foreach (var file in sourceFile.Items())
            {
                
                destinationFolder.CopyHere(file, 4 | 16);
            }
        }

        private void btnInstall_Click(object sender, RoutedEventArgs e)
        {

            if (txtInstallationRoutePath.Text == "" || txtInstallationRoutePath.Text == null)
            {
                MessageBox.Show("Please select a folder");
            }
            else 
            {
                propertiesFile = txtInstallationRoutePath.Text;

                if (!Directory.Exists(propertiesFile))
                {
                    Directory.CreateDirectory(propertiesFile);
                    MessageBox.Show(propertiesFile);
                    unZip(@"C:\Users\sebas\source\repos\EReviewProgram\EReviewProgram\ZIPfiles\ereview.zip", PropertiesFile);
                }
                else 
                {
                    MessageBox.Show(propertiesFile);
                    unZip(@"C:\Users\sebas\source\repos\EReviewProgram\EReviewProgram\ZIPfiles\ereview.zip", PropertiesFile);
                }

                InstallationProgress page = new InstallationProgress();
                page.Show();
                this.Hide();
            }
        }

        private void btnBrowseFolder_Click(object sender, RoutedEventArgs e)
        {
            var ookiiDialog = new VistaFolderBrowserDialog();
            if (ookiiDialog.ShowDialog() == true)
            {
                txtInstallationRoutePath.Text = ookiiDialog.SelectedPath;
                propertiesFile = ookiiDialog.SelectedPath;
            }
        }

        private void txtInstallationRoutePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            //PropertiesFile = txtInstallationRoutePath.Text;
        }
    }
}
