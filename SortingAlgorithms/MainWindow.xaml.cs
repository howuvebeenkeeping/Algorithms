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
                    var item = new SortingItem(rnd.Next(10, 100), Items.Count + 1);
                    Items.Add(item);
                }
            }

            TextBoxFillWithRandom.Text = string.Empty;
        }

        private async void BtnBubbleSort_Click(object sender, RoutedEventArgs e)
        {
            var bubbleSort = new BubbleSort<SortingItem>(this.Items);
            bubbleSort.ColorChanged += OnColorChangedEvent;
            var totalTime = await bubbleSort.Sort(visualizationOn: true);
            FillLabels(bubbleSort.SwapCount, bubbleSort.CompareCount, totalTime);
        }
        
        private async void BtnCocktailSort_OnClick(object sender, RoutedEventArgs e)
        {
            var cocktailSort = new CocktailSort<SortingItem>(this.Items);
            cocktailSort.ColorChanged += OnColorChangedEvent;
            var totalTime = await cocktailSort.Sort(visualizationOn: true);
            FillLabels( cocktailSort.SwapCount, cocktailSort.CompareCount, totalTime);
        }

        private async void BtnInsertSort_OnClick(object sender, RoutedEventArgs e)
        {
            var insertSort = new InsertSort<SortingItem>(this.Items);
            insertSort.ColorChanged += OnColorChangedEvent;
            var totalTime = await insertSort.Sort(visualizationOn: true);
            FillLabels(insertSort.SwapCount, insertSort.CompareCount, totalTime);
        }

        private async void BtnShellSort_OnClick(object sender, RoutedEventArgs e)
        {
            var shellSort = new ShellSort<SortingItem>(this.Items);
            shellSort.ColorChanged += OnColorChangedEvent;
            var totalTime = await shellSort.Sort(visualizationOn: true);
            FillLabels(shellSort.SwapCount, shellSort.CompareCount, totalTime);
        }

        private void FillLabels(int swapCount, int compareCount, TimeSpan totalTime)
        {
            LblSwapCount.Content = $"Кол-во замен/вставок: {swapCount}";
            LblCompareCount.Content = $"Кол-во сравнений: {compareCount}";
            LblTotalTime.Content = $"Время сортировки: {totalTime}";
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