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
            bubbleSort.CompareEvent += SortOnCompareEvent;
            bubbleSort.SwapEvent += SortOnSwapEvent;
            bubbleSort.ColorsDefaultEvent += SortOnColorsDefaultEvent;
            bubbleSort.Sort();
        }

        private void SortOnColorsDefaultEvent(object sender, Tuple<SortingItem, SortingItem> e)
        {
            e.Item1.SetColor(Colors.Green);
            e.Item2.SetColor(Colors.Green);
        }

        private void SortOnSwapEvent(object sender, Tuple<SortingItem, SortingItem> e)
        {
            e.Item1.SetColor(Colors.Red);
            e.Item2.SetColor(Colors.Red);
        }

        private void SortOnCompareEvent(object sender, Tuple<SortingItem, SortingItem> e)
        {
            e.Item1.SetColor(Colors.Blue);
            e.Item2.SetColor(Colors.Blue);
        }

        private void BtnCocktailSort_OnClick(object sender, RoutedEventArgs e)
        {
            var cocktailSort = new CocktailSort<SortingItem> {Items = this.Items};
            cocktailSort.CompareEvent += SortOnCompareEvent;
            cocktailSort.SwapEvent += SortOnSwapEvent;
            cocktailSort.ColorsDefaultEvent += SortOnColorsDefaultEvent;
            cocktailSort.Sort();
        }
    }
}