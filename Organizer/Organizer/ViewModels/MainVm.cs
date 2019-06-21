using Organizer.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Organizer.Data;
using Xamarin.Forms;

namespace Organizer.ViewModels
{
    public class MainVm : ViewModelBase
    {
        public ObservableCollection<TaskVm> Tasks { get; }

        public ICommand Add { get; }

        private void AddCommand()
        {
            App.Current.GoToAddTask();
        }

        public MainVm()
        {
            Tasks = new ObservableCollection<TaskVm>();
            Add = new Command(AddCommand);
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
