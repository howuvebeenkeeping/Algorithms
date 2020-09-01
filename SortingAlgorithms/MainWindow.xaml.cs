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
        //private readonly SortBase<int> _bubbleSort = new BubbleSort<int>();
        //private readonly IList<ProgressBar> _progressBars= new List<ProgressBar>();
        //private readonly IList<Label> _lables = new List<Label>();
        //private static readonly Random Random = new Random();
        private List<SortingItem> items = new List<SortingItem>();

        public MainWindow()
        {
            InitializeComponent();
            #region ttt
            //for (var i = 0; i < 8; i++)
            //{
            //    _bubbleSort.Items.Add(Random.Next(0, 100));
            //}

            //foreach(var UIElement in StackPanelProgressBars.Children)
            //{
            //    if (!(UIElement is StackPanel stackPanel)) continue;
            //    foreach (var @object in stackPanel.Children)
            //    {
            //        switch (@object)
            //        {
            //            case ProgressBar progressBar:
            //                _progressBars.Add(progressBar);
            //                break;
            //            case Label label:
            //                _lables.Add(label);
            //                break;
            //        }
            //    }
            //}

            //foreach (var progressBar in _progressBars)
            //{
            //    progressBar.Foreground = new SolidColorBrush(Colors.Blue);
            //}
            //UpdateWithItems(_bubbleSort.Items);
            #endregion
        }

        //private void UpdateWithItems(IList<int> items)
        //{    
        //    for (var i = 0; i < items.Count; i++)
        //    {
        //        _progressBars[i].Value = items[i];
        //        _lables[i].Content = items[i].ToString();
        //    }
        //}

        //private void BtnSort_OnClick(object sender, RoutedEventArgs e)
        //{
        //    _bubbleSort.Sort();
        //    UpdateWithItems(_bubbleSort.Items);
        //}

        private void BtnAddNumber_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxAddNumber.Text, out int value))
            {
                var item = new SortingItem(value);
                items.Add(item);
                StackPanelProgressBars.Children.Add(item.StackPanel);
            }

            TextBoxAddNumber.Text = string.Empty;
        }

        private void BtnFillWithRandom_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxFillWithRandom.Text, out int value))
            {
                var rnd = new Random();

                for (int i = 0; i < value; i++)
                {
                    var item = new SortingItem(rnd.Next(0, 100));
                    items.Add(item);
                    StackPanelProgressBars.Children.Add(item.StackPanel);
                }
            }

            TextBoxFillWithRandom.Text = string.Empty;
        }
    }
}