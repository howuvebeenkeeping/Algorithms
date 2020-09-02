using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SortingAlgorithms
{
    public class SortingItem : IComparable, INotifyPropertyChanged
    {
        public StackPanel StackPanel { get; set; }
        public ProgressBar ProgressBar { get; set; }
        public Label Label { get; set; }
        public int Value { get; set; }
        private SolidColorBrush color;
        public SolidColorBrush Color
        {
            get => color;
            set
            {
                NotifyPropertyChanged(ref color, value, nameof(Color));
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public SortingItem() {}

        public SortingItem(int value, int number)
        {
            Value = value;

            Color = new SolidColorBrush(Colors.Green);
            
            ProgressBar = new ProgressBar
            {
                Name = $"ProgressBar{number}",
                Width = 20,
                Height = 100,
                Orientation = Orientation.Vertical,
                Foreground = Color,
                Value = this.Value,
                Margin = new Thickness(8, 0, 0, 0),
            };

            Label = new Label
            {
                Name = $"Label{number}",
                Content = Value.ToString(),
                Margin = new Thickness(7, 0, 0, 0)
            };

            StackPanel = new StackPanel
            {
                Name = $"StackPanelElement{number}",
                Margin = new Thickness(5, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
            };

            StackPanel.Children.Add(ProgressBar);
            StackPanel.Children.Add(Label);
        }

        protected void NotifyPropertyChanged<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            oldValue = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int CompareTo(object obj)
        {
            if (obj is SortingItem item)
            {
                return Value.CompareTo(item.Value);
            }
            throw new ArgumentException($@"obj is not {nameof(SortingItem)}", nameof(obj));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}