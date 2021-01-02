using System;
using System.Windows;
using System.Windows.Controls;

namespace TaskManager
{
    public partial class GoalView : UserControl
    {
        public Action<GoalView> Delete;
        public Action<GoalView> Open;
        public Action<GoalView> AddTask;

        public Goal Goal
        {
            get => _goal;
            set
            {
                _goal = value;
                GoalText.Content = _goal.Name + '\t' + _goal.Color;
            }
        }
        private Goal _goal;

        public GoalView() => InitializeComponent();

        public GoalView(Goal goal)
        {
            InitializeComponent();

            Goal = goal;

            GoalText.Click += OpenImageButton_Click;
            DeleteImageButton.Click += DeleteImageButton_Click;
            AddTaskButton.Click += AddTaskButton_Click;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e) => AddTask(this);

        private void OpenImageButton_Click(object sender, RoutedEventArgs e) => Open(this);

        private void DeleteImageButton_Click(object sender, RoutedEventArgs e) => Delete(this);
    }
}
