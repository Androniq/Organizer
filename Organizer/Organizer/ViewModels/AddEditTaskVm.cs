using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Organizer.Enums;
using Organizer.Mvvm;
using Xamarin.Forms;

namespace Organizer.ViewModels
{
    public class AddEditTaskVm : ViewModelBase
    {
        private int _busy;

        private TaskVm _task;

        /// <summary>
        /// Gets or sets Task value.
        /// </summary>
        public TaskVm Task
        {
            get => _task;
            set => SetValue(ref _task, value, TaskChanged);
        }

        private void TaskChanged(TaskVm oldValue, TaskVm newValue)
        {
            if (oldValue != null)
            {
                oldValue.PropertyChanged -= TaskPropertyChanged;
            }
            if (newValue != null)
            {
                newValue.PropertyChanged += TaskPropertyChanged;
            }
            TaskPropertyChanged(null, null);
        }

        private bool _isDueDateVisible;

        /// <summary>
        /// Gets or sets IsDueDateVisible value.
        /// </summary>
        public bool IsDueDateVisible
        {
            get => _isDueDateVisible;
            set => SetValue(ref _isDueDateVisible, value);
        }

        private bool _isAdd;

        /// <summary>
        /// Gets or sets IsAdd value.
        /// </summary>
        public bool IsAdd
        {
            get => _isAdd;
            set => SetValue(ref _isAdd, value);
        }

        private bool _isEdit;

        /// <summary>
        /// Gets or sets IsEdit value.
        /// </summary>
        public bool IsEdit
        {
            get => _isEdit;
            set => SetValue(ref _isEdit, value);
        }

        public ICommand Add { get; }

        public ICommand Edit { get; }

        private void TaskPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsDueDateVisible = Task != null && (Task.Type == TaskType.Fixed || Task.Type == TaskType.Deadline);
        }

        public AddEditTaskVm()
        {
            Task = new TaskVm();
            Add = new Command(AddCommand);
            Edit = new Command(EditCommand);
        }

        public void Init()
        {
            IsAdd = true;
        }

        public void Init(TaskVm task)
        {
            Task = task;
            IsEdit = true;
        }

        private async void AddCommand()
        {
            if (!Validate())
                return;
            if (Interlocked.CompareExchange(ref _busy, 1, 0) != 0)
                return;
            await App.Current.Storage.AddTask(Task.Save());
            App.Current.GoToMain();
        }

        private async void EditCommand()
        {
            if (!Validate())
                return;
            if (Interlocked.CompareExchange(ref _busy, 1, 0) != 0)
                return;
            await App.Current.Storage.UpdateTask(Task.Save());
            App.Current.GoToMain();
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(Task.Title))
            {
                return false;
            }
            return true;
        }
    }
}
