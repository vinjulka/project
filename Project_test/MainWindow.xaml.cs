using System;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
using MathParser;
using Microsoft.Win32;


namespace Project_test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Valid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sDialog = new SaveFileDialog();

            sDialog.Filter = "Текстовые документы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            sDialog.FilterIndex = 2;
            sDialog.RestoreDirectory = true;
            Nullable<bool> result = sDialog.ShowDialog();
            if (result == true)
            {
                string filename = sDialog.FileName;
                File.WriteAllText(filename, textBox2.Text);
            }
        }


        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            string[] s = textBox2.Text.Split(new string[] { "\n\r"}, StringSplitOptions.RemoveEmptyEntries);
            int[][] ar = new int[s.Length][];
            for (int i = 0; i < s.Length; i++)
            {
                ar[i] = new int[s[0].Length];
            }


        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oDialog = new OpenFileDialog();
            oDialog.Filter = "Текстовые документы (.txt)|*.txt";

            Nullable<bool> result = oDialog.ShowDialog();

            if (result==true)
            {
                string filename = oDialog.FileName;
                textBox2.Text = File.ReadAllText(filename);
            }
        }

        private void rand_mas_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(function_text.Text);
            Random random = new Random();
            int[,] a = new int[n, n];
            textBox2.Clear();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int rand = -100 + random.Next(200);
                    a[i, j] = rand;
                    textBox2.Text += a[i, j] +"\t";
                }
                textBox2.Text += "\n\r";
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = a[i, j];
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная программа предназначена для решения СЛАУ методом Крамера", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
