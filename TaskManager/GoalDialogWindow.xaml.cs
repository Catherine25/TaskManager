using System.Windows;

namespace TaskManager
{
    public partial class GoalDialogWindow : Window
    {
        public Goal Goal;

        public GoalDialogWindow()
        {
            InitializeComponent();

            Goal = new Goal();

            OkButton.Click += OkButton_Click;
            CancelButton.Click += CancelButton_Click;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Goal.Name = GoalNameTextBox.Text;
            Goal.Color = GoalColorTextBox.Text;
            DialogResult = true;
            Close();
        }
    }
}
