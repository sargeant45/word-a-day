using System;
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
using System.Windows.Forms;

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
            checkSpeech();
        }

        public void checkSpeech()
        {
            if (language.SelectedIndex > 0)
            {
                button3.IsEnabled = false;
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string define = label1.Content.ToString();
            if (language.SelectedIndex == 0)
            {
                System.Diagnostics.Process.Start("http://www.dictionary.reference.com/browse/" + define);
            }
            else
            {
                if (language.SelectedIndex == 1)
                {
                    System.Diagnostics.Process.Start("http://www.spanish.dictionary.com/define/" + define);
                }
                else
                {
                    if (language.SelectedIndex == 2)
                    {
                        System.Diagnostics.Process.Start("http://www.collinsdictionary.com/dictionary/german-english/" + define + "?showCookiePolicy=true");
                    }
                    else
                    {
                        if (language.SelectedIndex == 3)
                        {
                            System.Diagnostics.Process.Start("http://www.collinsdictionary.com/dictionary/french-english/" + define + "?showCookiePolicy=true");
                        }
                    }
                }
                
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            newWord();
        }

        public void newWord()
        {
            #region Create path variables
            string dictionarypath = "generic";
            string path = "generic";
            // Setting the dictionary path and excluded words path so the program doesn't bug out. It will
            // be changed in a second.
            if (language.SelectedIndex == 0)
            {
                dictionarypath = Directory.GetCurrentDirectory() + "/Dictionaries/dictionary.txt";
                path = Directory.GetCurrentDirectory() + "/Dictionaries/excludedwords.txt";
            }
            else
            {
                if (language.SelectedIndex == 1)
                {
                    dictionarypath = Directory.GetCurrentDirectory() + "/Dictionaries/spanishdictionary.txt";
                    path = Directory.GetCurrentDirectory() + "/Dictionaries/excludedwords.txt";
                }
                else
                {
                    if (language.SelectedIndex == 2)
                    {
                        dictionarypath = Directory.GetCurrentDirectory() + "/Dictionaries/germandictionary.txt";
                        path = Directory.GetCurrentDirectory() + "/Dictionaries/excludedwords.txt";
                    }
                    else
                    {
                        if (language.SelectedIndex == 3)
                        {
                            dictionarypath = Directory.GetCurrentDirectory() + "/Dictionaries/frenchdictionary.txt";
                            path = Directory.GetCurrentDirectory() + "/Dictionaries/excludedwords.txt";
                        }
                    }
                }
            }
            #endregion

            #region Setup
            Random word = new Random();
            int randomword = word.Next(1, 58110);
            string[] lines = File.ReadAllLines(dictionarypath);
            string[] excludedlines;
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            excludedlines = File.ReadAllLines(path);
            string chosenWord = lines[randomword];
            #endregion

            #region Logic
            if (excludedlines.Count() == 58110)
            {
                File.WriteAllText(path, "");
            }
            if (excludedlines.Contains(chosenWord))
            {
                while (excludedlines.Contains(chosenWord))
                {
                    randomword = word.Next(58110);
                    chosenWord = lines[randomword];
                }
                
                File.AppendAllText(path, chosenWord + Environment.NewLine);
                excludedlines = File.ReadAllLines(path);
                label1.Content = chosenWord;

            }
            else
            {
                File.AppendAllText(path, chosenWord + Environment.NewLine);
                excludedlines = File.ReadAllLines(path);
                label1.Content = chosenWord;
            }
            #endregion
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
            if (language.SelectedIndex == 0)
            {
                SpeechSynthesizer say = new SpeechSynthesizer();
                say.SetOutputToDefaultAudioDevice();
                say.Speak(label1.Content.ToString());
            }
            else
            {
                
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:ethanarterberry@gmail.com");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            givethanks.IsOpen = true;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(label1.Content.ToString());
            button4.Content = "Copied!";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "/Dictionaries/excludedwords.txt";
            string allpastwords = File.ReadAllText(path);
            pastwordsbox.Text = allpastwords;
            pastwords.IsOpen = true;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "/Dictionaries/excludedwords.txt";
            File.WriteAllText(path, "");
            pastwordsbox.Text = " ";
        }

        private void language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkSpeech();
        }

    }
}
