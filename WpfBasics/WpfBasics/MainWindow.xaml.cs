using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfBasics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The discription is: {txtDescription.Text}");
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            chkAssambly.IsChecked = chkDrill.IsChecked = chkFold.IsChecked = chkLaser.IsChecked = chkLathe.IsChecked = chkPlasma.IsChecked = chkPurchase.IsChecked = chkRold.IsChecked = chkSaw.IsChecked = chkWeld.IsChecked = false;
            txtLenght.Text = "";
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chk_Checked(object sender, RoutedEventArgs e)
        {
            
            txtLenght.Text += (txtLenght.Text == "" ? (((CheckBox)sender).Content).ToString() : "," + (((CheckBox)sender).Content).ToString());

        }

        private void Finish_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtNote == null)
            {
                return;
            }
            // değişim yapıldıgında eski verinin silinip yenisinin yazılması gerekiyor.
            txtNote.Text += ((ComboBoxItem)((ComboBox)sender).SelectedValue).Content.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Finish_SelectionChanged(cmbFinish, null);
            cmbPurchase_SelectionChanged(cmbPurchase, null);
        }

        private void cmbPurchase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtNote == null)
            {
                return;
            }
            txtNote.Text += ", " + ((ComboBoxItem)((ComboBox)sender).SelectedValue).Content.ToString();
        }

        private void txtSupplierName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtSupplierCode.Text = Regex.Replace(txtSupplierName.Text, " ", "");
            txtSupplierCode.Text += txtSupplierCode.Text.Length;
        }

        private void chk_Unchecked(object sender, RoutedEventArgs e)
        {
            
            // checkboxlar unchecked oldugunda lenght.text kısmından silinecek
        }
    }
}
