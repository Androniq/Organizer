using System;
using Organizer.Enums;
using SQLite;

namespace Organizer.Models
{
    public class TaskModel
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public TaskType Type { get; set; }

        public DateTime? DueDate { get; set; }

        public TimeSpan? DueDateTolerance { get; set; }

        public string Description { get; set; }

        public string Checklist { get; set; }

        public TaskState State { get; set; }

        public TaskPriority Priority { get; set; }
    }
}
