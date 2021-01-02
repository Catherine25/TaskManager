using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TaskManager
{
    [Serializable]
    public class Goal
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public List<Task> Tasks { get; set; }
    }
}
