using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SortingAlgorithms
{
    public class SortingItem
    {
        public StackPanel StackPanel { get; set; }
        public ProgressBar ProgressBar { get; set; }
        public Label Label { get; private set; }
        public int Value { get; set; }

        public SortingItem(int value)
        {
            Value = value;

            ProgressBar = new ProgressBar
            {
                Width = 20,
                Height = 100,
                Orientation = Orientation.Vertical,
                Foreground = new SolidColorBrush(Colors.Blue),
                Value = this.Value,
                Margin = new Thickness(8, 0, 0, 0)
            };

            Label = new Label
            {
                Content = Value.ToString(),
                Margin = new Thickness(7, 0, 0, 0)
            };

            StackPanel = new StackPanel
            {
                Margin = new Thickness(5, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
            };

            StackPanel.Children.Add(ProgressBar);

            StackPanel.Children.Add(Label);
        }
    }
}
