using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Organizer.Enums;
using Organizer.Models;
using Organizer.Mvvm;

namespace Organizer.ViewModels
{
    public class TaskVm : ViewModelBase
    {
        private string _title;

        /// <summary>
        /// Gets or sets Title value.
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        private TaskType _type;

        /// <summary>
        /// Gets or sets Type value.
        /// </summary>
        public TaskType Type
        {
            get => _type;
            set => SetValue(ref _type, value);
        }

        private TaskState _state;

        /// <summary>
        /// Gets or sets State value.
        /// </summary>
        public TaskState State
        {
            get => _state;
            set => SetValue(ref _state, value);
        }

        private DateTime? _dueDate;

        /// <summary>
        /// Gets or sets DueDate value.
        /// </summary>
        public DateTime? DueDate
        {
            get => _dueDate;
            set => SetValue(ref _dueDate, value);
        }

        private TimeSpan? _dueDateTolerance;

        /// <summary>
        /// Gets or sets DueDateTolerance value.
        /// </summary>
        public TimeSpan? DueDateTolerance
        {
            get => _dueDateTolerance;
            set => SetValue(ref _dueDateTolerance, value);
        }

        private TaskPriority _priority;

        /// <summary>
        /// Gets or sets Priority value.
        /// </summary>
        public TaskPriority Priority
        {
            get => _priority;
            set => SetValue(ref _priority, value);
        }

        private string _description;

        /// <summary>
        /// Gets or sets Description value.
        /// </summary>
        public string Description
        {
            get => _description;
            set => SetValue(ref _description, value);
        }

        private int _id;

        /// <summary>
        /// Gets or sets Id value.
        /// </summary>
        public int Id
        {
            get => _id;
            set => SetValue(ref _id, value);
        }

        public ObservableCollection<ChecklistItemVm> Checklist { get; }

        public TaskVm()
        {
            Checklist = new ObservableCollection<ChecklistItemVm>();
            Type = TaskType.Deadline;
            State = TaskState.Actual;
            Priority = TaskPriority.Average;
        }

        public TaskModel Save()
        {
            return new TaskModel
            {
                Id = Id,
                Title = Title,
                Description = Description,
                DueDate = DueDate,
                DueDateTolerance = DueDateTolerance,
                Priority = Priority,
                State = State,
                Type = Type,
                Checklist = JsonConvert.SerializeObject(Checklist.ToArray())
            };
        }

        public static TaskVm Create(TaskModel task)
        {
            var taskVm = new TaskVm
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                DueDateTolerance = task.DueDateTolerance,
                Priority = task.Priority,
                State = task.State,
                Type = task.Type
            };
            if (!string.IsNullOrEmpty(task.Checklist))
            {
                var items = JsonConvert.DeserializeObject<ChecklistItem[]>(task.Checklist);
                foreach (var item in items)
                {
                    var itemVm = new ChecklistItemVm();
                    itemVm.Load(item);
                    taskVm.Checklist.Add(itemVm);
                }
            }
            return taskVm;
        }
    }
}
