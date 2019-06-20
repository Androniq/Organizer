using Organizer.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Organizer.Data;

namespace Organizer.ViewModels
{
    public class MainVm : ViewModelBase
    {
        public ObservableCollection<TaskVm> Tasks { get; }

        public MainVm()
        {
            Tasks = new ObservableCollection<TaskVm>();
        }

        public async Task Load()
        {
            var tasks = await App.Current.Storage.GetTasks();
            Tasks.Clear();
            foreach (var taskModel in tasks)
            {
                Tasks.Add(TaskVm.Create(taskModel));
            }
        }

        public async void Save()
        {
        }
    }
}
