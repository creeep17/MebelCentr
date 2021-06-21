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
using System.Threading;

namespace loginkosto4
{
    /// <summary>
    /// Логика взаимодействия для loginWin.xaml
    /// </summary>
    public partial class loginWin : Window
    {
        

        public loginWin()
        {
            SplashScreen splash = new SplashScreen("kazakh.png");
            splash.Show(true);
            Thread.Sleep(2000);

            InitializeComponent();
            

        }


       
        
        private void VisiblePass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            if (checkbox.IsChecked == true)
            {
                visiblePass.Text = passBox.Password;
                visiblePass.Visibility = Visibility.Visible;
                passBox.Visibility = Visibility.Hidden;
            }
            else
            {
                passBox.Password = visiblePass.Text;
                visiblePass.Visibility = Visibility.Hidden;
                passBox.Visibility = Visibility.Visible;
            }


        }

        private void LogBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Passbtn_Click(object sender, RoutedEventArgs e)
        {
            var passrod = checkbox.IsChecked.Value ? visiblePass.Text : passBox.Password;
            MessageBox.Show(passrod);
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            string log = "vadim";
            string pass = "kos";


            if (logBox.Text == log)
            {
                if (passBox.Password == pass)
                {

                    winZakaz winZ = new winZakaz();
                    winZ.Show();
                    this.Hide();
                }

            }
            /*else
            {
                captchaWin capwin = new captchaWin();
                capwin.Show();
                this.Hide();
            }*/
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void logBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
