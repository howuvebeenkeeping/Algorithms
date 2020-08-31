using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Algorithms;

namespace SortingAlgorithms
{
    public partial class MainWindow
    {
        private readonly SortBase<int> _bubbleSort = new BubbleSort<int>();
        private readonly IList<ProgressBar> _progressBars= new List<ProgressBar>();
        private readonly IList<Label> _lables = new List<Label>();
        private static readonly Random Random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            for (var i = 0; i < 8; i++)
            {
                _bubbleSort.Items.Add(Random.Next(0, 100));
            }

            foreach(var UIElement in StackPanelProgressBars.Children)
            {
                if (!(UIElement is StackPanel stackPanel)) continue;
                foreach (var @object in stackPanel.Children)
                {
                    switch (@object)
                    {
                        case ProgressBar progressBar:
                            _progressBars.Add(progressBar);
                            break;
                        case Label label:
                            _lables.Add(label);
                            break;
                    }
                }
            }
            
            foreach (var progressBar in _progressBars)
            {
                progressBar.Foreground = new SolidColorBrush(Colors.Blue);
            }
            UpdateWithItems(_bubbleSort.Items);
        }

        private void UpdateWithItems(IList<int> items)
        {    
            for (var i = 0; i < items.Count; i++)
            {
                _progressBars[i].Value = items[i];
                _lables[i].Content = items[i].ToString();
            }
        }
        
        private void BtnSort_OnClick(object sender, RoutedEventArgs e)
        {
            _bubbleSort.Sort();
            UpdateWithItems(_bubbleSort.Items);
        }
    }
}