using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Gauges;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TimePicker
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            DateTime currentDateTime = DateTime.Now;
            this.HoursTextBlock.Text = currentDateTime.ToString("hh");
            this.MinutesTextBlock.Text = currentDateTime.Minute.ToString("00");
            this.MinutesTextBlock.Foreground.Opacity = 0.5;
            this.pointer.Value = Convert.ToDouble(this.HoursTextBlock.Text);
            this.ContentTextBlock.Text = this.HoursTextBlock.Text;
            if (currentDateTime.ToString("tt") == "AM")
            {
                this.PMTextBlock.Foreground.Opacity = 0.5;
            }
            else
            {
                this.AMTextBlock.Foreground.Opacity = 0.5;
            }
        }

        private void HoursTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.timerPickerAxis.Maximum = 12;
            this.timerPickerAxis.Interval = 1;
            this.pointer.Value = Convert.ToDouble(this.HoursTextBlock.Text);
            this.ContentTextBlock.Text = this.HoursTextBlock.Text;
            this.HoursTextBlock.Foreground.Opacity = 1;
            this.MinutesTextBlock.Foreground.Opacity = 0.5;
        }

        private void MinutesTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.timerPickerAxis.Maximum = 60;
            this.timerPickerAxis.Interval = 5;
            this.pointer.Value = Convert.ToDouble(this.MinutesTextBlock.Text);
            this.ContentTextBlock.Text = this.MinutesTextBlock.Text;
            this.HoursTextBlock.Foreground.Opacity = 0.5;
            this.MinutesTextBlock.Foreground.Opacity = 1;
        }

        private void AMTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.AMTextBlock.Foreground.Opacity = 1;
            this.PMTextBlock.Foreground.Opacity = 0.5;
        }

        private void PMTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.AMTextBlock.Foreground.Opacity = 0.5;
            this.PMTextBlock.Foreground.Opacity = 1;
        }

        private void pointer_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            double newValue = 0;
            if (e.NewValue != 60)
            {
                newValue = (int)e.NewValue;
            }

            this.ContentTextBlock.Text = newValue.ToString("00");
            if (this.timerPickerAxis.Maximum == 12)
            {
                this.HoursTextBlock.Text = this.ContentTextBlock.Text;
            }
            else
            {
                this.MinutesTextBlock.Text = this.ContentTextBlock.Text;
            }
        }

        private void pointer_ValueChangeCompleted(object sender, ValueChangedEventArgs e)
        {
            if (this.timerPickerAxis.Maximum == 12)
            {
                this.timerPickerAxis.Maximum = 60;
                this.timerPickerAxis.Interval = 5;
                this.pointer.Value = Convert.ToDouble(this.MinutesTextBlock.Text);
                this.ContentTextBlock.Text = this.MinutesTextBlock.Text;
                this.HoursTextBlock.Foreground.Opacity = 0.5;
                this.MinutesTextBlock.Foreground.Opacity = 1;
            }
        }
    }
}
