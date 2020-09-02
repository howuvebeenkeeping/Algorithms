using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Algorithms;
using Algorithms.SortingAlgorithms;

namespace SortingAlgorithms
{
    public partial class MainWindow
    {
        public ObservableCollection<SortingItem> Items { get; set; } = new ObservableCollection<SortingItem>();
        
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
        
        private void BtnAddNumber_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxAddNumber.Text, out var value))
            {
                var item = new SortingItem(value, Items.Count + 1);
                Items.Add(item);
            }

            TextBoxAddNumber.Text = string.Empty;
        }

        private void BtnFillWithRandom_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxFillWithRandom.Text, out var value))
            {
                var rnd = new Random();

                for (var i = 0; i < value; i++)
                {
                    var item = new SortingItem(rnd.Next(100), Items.Count + 1);
                    Items.Add(item);
                }
            }

            TextBoxFillWithRandom.Text = string.Empty;
        }

        private void BtnBubbleSort_Click(object sender, RoutedEventArgs e)
        {
            var bubbleSort = new BubbleSort<SortingItem> {Items = this.Items};
            bubbleSort.ColorChanged += OnColorChangedEvent;
            bubbleSort.Sort(true);
        }
        
        private void BtnCocktailSort_OnClick(object sender, RoutedEventArgs e)
        {
            var cocktailSort = new CocktailSort<SortingItem> {Items = this.Items};
            cocktailSort.ColorChanged += OnColorChangedEvent;
            cocktailSort.Sort(true);
        }

        private void BtnInsertSort_OnClick(object sender, RoutedEventArgs e)
        {
            var insertSort = new InsertSort<SortingItem> {Items = this.Items};
            insertSort.ColorChanged += OnColorChangedEvent;
            insertSort.Sort(true);
        }

        private void OnColorChangedEvent(object sender, Tuple<SortingItem, SortingItem, SortBase<SortingItem>.ChangeColor> e)
        {
            switch (e.Item3)
            {
                case SortBase<SortingItem>.ChangeColor.Swap:
                    e.Item1.Color = new SolidColorBrush(Colors.Red);
                    e.Item2.Color = new SolidColorBrush(Colors.Red);
                    break;
                case SortBase<SortingItem>.ChangeColor.Compare:
                    e.Item1.Color = new SolidColorBrush(Colors.Blue);
                    e.Item2.Color = new SolidColorBrush(Colors.Blue);
                    break;
                case SortBase<SortingItem>.ChangeColor.Default:
                    e.Item1.Color = new SolidColorBrush(Colors.Green);
                    e.Item2.Color = new SolidColorBrush(Colors.Green);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}