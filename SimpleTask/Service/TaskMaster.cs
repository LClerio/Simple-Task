using SimpleTask.Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTask.Service
{
    internal class TaskMaster
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public TasksStatus IsCompleted { get; set; }

        public TaskMaster() { }

        public TaskMaster(int id, string description, TasksStatus isCompleted)
        {
            ID = id;
            Description = description;
            IsCompleted = isCompleted;
        }
    }
}
