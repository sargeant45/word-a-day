﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro;
using MahApps.Metro.Controls;
using System.Windows.Interop;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;

namespace WordADay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            newWord();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string define = label1.Content.ToString();
            System.Diagnostics.Process.Start("http://www.dictionary.reference.com/browse/" + define);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            newWord();
        }

        public void newWord()
        {
            string dictionarypath = Directory.GetCurrentDirectory() + "/dictionary.txt";
            List<string> lines = new List<string>();

            // 2
            // Use using StreamReader for disposing.
            using (StreamReader r = new StreamReader(dictionarypath))
            {
                // 3
                // Use while != null pattern for loop
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    // 4
                    // Insert logic here.
                    // ...
                    // "line" is a line in the file. Add it to our List.
                    lines.Add(line);
                }
            }
            Random word = new Random();
            int randomword = word.Next(1, 58110);
            label1.Content = ((string)lines[randomword]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            about.IsOpen = true;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://sargeant45.github.com");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer say = new SpeechSynthesizer();
            say.SetOutputToDefaultAudioDevice();
            say.Speak(label1.Content.ToString());
        }

    }
}