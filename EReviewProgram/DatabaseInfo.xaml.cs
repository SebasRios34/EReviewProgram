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

namespace EReviewProgram
{
    /// <summary>
    /// Interaction logic for DatabaseInfo.xaml
    /// </summary>
    public partial class DatabaseInfo : Window
    {
        public DatabaseInfo()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            InitializeServers page = new InitializeServers();
            page.Show();
            this.Close();
        }
    }
}
