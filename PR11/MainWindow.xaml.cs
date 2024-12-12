using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR11
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

        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            var s = sender as Button;
            switch(s.Content)
            {
                case "Найти" : FoundText(); break ;
                case "Выход" : Close(); break ;
                case "Найти ": FoundTextAndNumber(); break;
            }
        }
        //Дана строка 'aa aba abba abbba abca abea'. Напишите регулярное выражение, которое найдет строки aa, aba.
        //Напишите регулярное выражение, которое найдет строки следующего вида: по краям стоят буквы 'a', а между ними - цифра от 3-х до 7-ми.

        string s = "aa aba abba abbba abca abea a34567a";
        private void FoundText()
        {
            Regex regex = new Regex(@"aa(\w*) | aba(\w*)");
            Match match = regex.Match(s);
            if (match.Value != "")
            {
                MatchCollection matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    object[] mas = new object[matches.Count];
                    matches.CopyTo(mas, 0);
                    lbText.ItemsSource = mas;
                }
            }
            else MessageBox.Show("Совпадения не найдены");
        }
        private void FoundTextAndNumber()
        {
            Regex regex = new Regex (@"a\d{3,7}a");
            Match match = regex.Match(s);
            MatchCollection matches2 = regex.Matches(s);
            if (matches2.Count > 0)
            {
                object[] mas = new object[matches2.Count];
                matches2.CopyTo(mas, 0);
                lbText.ItemsSource = mas;
            }
        }
    }
}