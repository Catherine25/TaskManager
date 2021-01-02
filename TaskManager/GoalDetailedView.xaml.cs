using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace TaskManager
{
    public partial class GoalDetailedView : UserControl
    {
        public Goal Goal
        {
            get => _goal;
            set
            {
                _goal = value;
                GoalName.Text = _goal.Name;
                GoalColor.Text = _goal.Color;
            }
        }
        private Goal _goal;

        public GoalDetailedView()
        {
            InitializeComponent();

            ResultsViewMode.Items.Add("Week");
            ResultsViewMode.Items.Add("Month");
            ResultsViewMode.Items.Add("Year");
            ResultsViewMode.SelectedItem = "Week";

            if (ResultsViewMode.SelectedItem.ToString() == "Week")
            {
                ResultsGrid.Children.Add(DrawWeek());
            }

            //DayOfWeek weekDay = DateTime.Now.DayOfWeek;
            //weekDay == DayOfWeek.
        }

        private StackPanel DrawWeek()
        {
            var day = GetFirstDay();

            var stack = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            for (int i = 0; i < 7; i++)
            {
                Button button = new Button
                {
                    Width = 25,
                    Height = 25,
                    Background = new SolidColorBrush(Colors.DarkGray),
                    Margin = new System.Windows.Thickness(10),
                    Content = day.AddDays(i).Day
                };

                stack.Children.Add(button);
            }

            return stack;
        }

        private DateTime GetFirstDay()
        {
            var days = new List<DayOfWeek> {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday };

            DateTime now = DateTime.Now;
            return now.AddDays(-days.IndexOf(now.DayOfWeek));
        }
    }
}
