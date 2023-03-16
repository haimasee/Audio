using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Audio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Playlist
    {
        public string[] playlist;
        public List<string> names;
        public bool random = false;
        public bool repeat = false;
        public bool paused = false;
        public int selected = 0;
        public void Randomize()
        {
            selected = 0;
            random = !random;
            if (random)
            {
                playlist = playlist.ToList().OrderBy(x => x).ToArray();
            }
            else
            {
                Random r = new Random();
                playlist = playlist.ToList().OrderBy(x => r.Next()).ToArray(); // random sorting
                GetNames();
            }
        }
        public void NextSong()
        {
            if (selected == names.Count - 1)
            {
                selected = -1;
            }
            ++selected;
        }
        public void PrevSong()
        {
            if (selected == 0)
            {
                selected = names.Count;
            }
            --selected;
        }
        public void GetNames()
        {
            this.names = new List<string>();
            for (int i = 0; i < playlist.Length; i++)
            {
                FileInfo file = new FileInfo(playlist[i]);
                if (file.Exists && file.Extension == ".mp3")
                {
                    names.Add(file.FullName);
                }
            }
        }
    }
    public partial class MainWindow : Window
    {
        Playlist playlist = new Playlist();
        private void MoveSliderThread()
        {
            while (true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    try
                    {
                        slider.Value = mediaPlayer.Position.Ticks;
                        if (slider.Value == mediaPlayer.NaturalDuration.TimeSpan.Ticks)
                        {
                            if (playlist.repeat)
                                mediaPlayer.Position = new TimeSpan();
                            else
                                playlist.NextSong();
                        }
                        if (playlist.selected != listbox.SelectedIndex)
                        {
                            listbox.SelectedIndex = playlist.selected;
                            mediaPlayer.Position = new TimeSpan();
                        }

                    }
                    catch (Exception ex)
                    {
                        ///////// MessageBox.Show(ex.Message);
                    }

                });
                Thread.Sleep(100);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Repeat_Click(object sender, RoutedEventArgs e)
        {
            playlist.repeat = !playlist.repeat;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            playlist.NextSong();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (playlist.paused)
            {
                mediaPlayer.Stop();
                playlist.paused = !playlist.paused;
            }
            else
            {
                mediaPlayer.Play();
                playlist.paused = !playlist.paused;

            }
        }
        private void Previuos_Click(object sender, RoutedEventArgs e)
        {
            playlist.PrevSong();

        }

        private void Randomize_Click(object sender, RoutedEventArgs e)
        {
            playlist.Randomize();
            listbox.Items.Clear();
            foreach (string name in playlist.names)
            {
                var ms = new FileInfo(name);
                listbox.Items.Add(ms.Name);
            }
        }
        private void OpenExplorer(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog() { IsFolderPicker = true };
            CommonFileDialogResult opened = dialog.ShowDialog();
            playlist.playlist = Directory.GetFiles(dialog.FileName);
            playlist.GetNames();
            listbox.Items.Clear();
            foreach (string name in playlist.names)
            {
                var ms = new FileInfo(name);
                listbox.Items.Add(ms.Name);
            }
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int selected = listbox.SelectedIndex;
                playlist.selected = selected;
                string music = playlist.names[selected];
                mediaPlayer.Source = new Uri(music);
                mediaPlayer.Volume = 1;
            }
            catch { }
        }
        private void media_change(object sender, RoutedEventArgs e)
        {
            slider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.Ticks;
            Thread moveslider = new Thread(() =>
            {
                MoveSliderThread();
            });
            moveslider.Start();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Position = new TimeSpan(Convert.ToInt64(slider.Value));
        }
    }
}