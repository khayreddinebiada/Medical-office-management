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

namespace MePatients
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btn_Login (object sender, RoutedEventArgs e)
        {
            if (enModepasse.Text.Equals("DR.JAZOULI") && enModepasse.Text.Equals("15987DR.JAZOULI"))
            {

            }
        }
    }
}
