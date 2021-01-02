using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        private const string GoalsPath = "goals.txt";
        private readonly string GoalsFullPath;

        public MainWindow()
        {
            InitializeComponent();

            GoalsFullPath = Path.Combine(Environment.CurrentDirectory, GoalsPath);

            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;

            CreateGoalButton.Click += CreateGoalButton_Click;
            CreateTaskButton.Click += CreateTaskButton_Click;
            DeleteTaskButton.Click += DeleteTaskButton_Click;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using var sr = new StreamReader(GoalsFullPath);

            foreach (var item in JsonSerializer.Deserialize<List<Goal>>(sr.ReadToEnd()))
                CreateNewGoalView(item);
        }

        private void AddTask(GoalView obj)
        {
            var dw = new TaskDialogWindow();

            if (dw.ShowDialog() == true)
            {
                CreateNewTaskView(dw.Task);
            }
        }

        private void OpenGoal(GoalView obj) => DetailedVIew.Goal = obj.Goal;

        private void DeleteGoal(GoalView obj) => GoalsPanel.Children.Remove(obj);

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            using var sw = new StreamWriter(GoalsFullPath, false, Encoding.Unicode);

            List<Goal> goals = new List<Goal>();
            foreach (var item in GoalsPanel.Children)
                goals.Add((item as GoalView).Goal);

            sw.Write(JsonSerializer.Serialize(goals));
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CreateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CreateGoalButton_Click(object sender, RoutedEventArgs e)
        {
            var dw = new GoalDialogWindow();

            if (dw.ShowDialog() == true)
                CreateNewGoalView(dw.Goal);
        }

        private void CreateNewGoalView(Goal goal)
        {
            var goalItem = new GoalView(goal);
            goalItem.Open += OpenGoal;
            goalItem.Delete += DeleteGoal;
            goalItem.AddTask += AddTask;
            GoalsPanel.Children.Add(goalItem);
        }

        private void CreateNewTaskView(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
