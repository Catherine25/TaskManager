using System;

namespace TaskManager
{
    public enum Frequency { Daily, Weekly, Monthly, Yearly }

    public class Task
    {
        public string Name;
        public Frequency Frequency;
        public DateTime DueDate;
        public TimeSpan NextOccurenceIn;
    }
}
