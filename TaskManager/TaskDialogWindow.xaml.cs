using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TaskManager
{
    public partial class TaskDialogWindow : Window
    {
        public TaskDialogWindow()
        {
            InitializeComponent();
            OkButton.Click += OkButton_Click;
            CancelButton.Click += CancelButton_Click;
            Amount.TextChanged += NumericTextBox_TextChanged;
            RepeatingsTextBox.TextChanged += NumericTextBox_TextChanged;
        }

        private void NumericTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            textBox.Background = textBox.Text == "" || int.TryParse(textBox.Text, out int a)
                ? new SolidColorBrush(Colors.Transparent)
                : new SolidColorBrush(Colors.PaleVioletRed);
        }

        public Task Task;

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Name = TaskNameTextBox.Text;
            Task.DueDate = DueDateButton.SelectedDate.Value;

            Task.Frequency = (Frequency)Enum.Parse(typeof(Frequency), AmountType.Text);
            
            DialogResult = true;
        }
    }
}
