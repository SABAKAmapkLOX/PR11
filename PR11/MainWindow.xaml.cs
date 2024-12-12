using System;
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
                case "Найти":FoundText(); break ;
                case "Выход":this.Close(); break ;
            }
        }
        //Дана строка 'aa aba abba abbba abca abea'. Напишите регулярное выражение, которое найдет строки aa, aba.
        //Напишите регулярное выражение, которое найдет строки следующего вида: по краям стоят буквы 'a', а между ними - цифра от 3-х до 7-ми.

        string s = "aa aba abba abbba abca abea a[3-7]a";
        private void FoundText()
        {
            Regex regex = new Regex(tbText.Text);
            Match match = regex.Match(s);
            if (match.Value != "")
            {
                MessageBox.Show("Слово: " + match.Value + " Найдено под индексом: " + match.Index);
                MatchCollection matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    object[] mas = new object[matches.Count];
                    matches.CopyTo(mas, 0);
                    lbText.ItemsSource = mas;
                }
            }
            else MessageBox.Show("Совпадения не найдены");

            string regexPattern2 = @"a\d{3,7}a";
            MatchCollection matches2 = Regex.Matches(s, regexPattern2);
            Console.WriteLine("\nMatches for pattern 2:");
            if (matches2.Count > 0)
            {
                lbText
            }
        }
        private void FoundTextAndNumber()
        {

        }
    }
}