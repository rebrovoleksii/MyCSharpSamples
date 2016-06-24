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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenTyper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBlock userOutput;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize lable
            userOutput = sender as TextBlock;
        }

        private void OnEnterPressedHandler(object sender, KeyEventArgs e)
        {    
            var textBox = sender as TextBox;    
            if (e.Key == Key.Enter)
            {
                if (userOutput.Text != null)        
                {
                    var oldContent = userOutput.Text;
                    userOutput.Text = oldContent + Environment.NewLine + textBox.Text;
                    
                }
                else userOutput.Text = textBox.Text;
                textBox.Clear();      
            }                                                                          
        }
    }
}
