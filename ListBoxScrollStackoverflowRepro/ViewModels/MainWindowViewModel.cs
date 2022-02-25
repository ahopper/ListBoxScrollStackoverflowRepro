using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ListBoxScrollStackoverflowRepro.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        DispatcherTimer timer;
        int issue = 0;
        public ObservableCollection<string> Stuff { get; set; } = new();

        public MainWindowViewModel()
        {
            FillStuff();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(8000);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object? sender, EventArgs e)
        {
            if (++issue % 2 == 0)
            {
                FillStuff();
            }
            else
            {
                Stuff.Clear();
            }
        }
        public void FillStuff()
        {
            for (int i=0;i<100;i++)
            {
                Stuff.Add(new string($"Mildly intresting item {i} issue{issue}"));
            }
        }
    }
}
