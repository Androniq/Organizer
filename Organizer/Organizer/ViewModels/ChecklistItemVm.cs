using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Organizer.Extensions;
using Organizer.Models;
using Organizer.Mvvm;

namespace Organizer.ViewModels
{
    public class ChecklistItemVm : ViewModelBase
    {
        private bool _isChecked;

        /// <summary>
        /// Gets or sets IsChecked value.
        /// </summary>
        public bool IsChecked
        {
            get => _isChecked;
            set => SetValue(ref _isChecked, value);
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

        private TaskVm _dependentOn;

        /// <summary>
        /// Gets or sets DependentOn value.
        /// </summary>
        public TaskVm DependentOn
        {
            get => _dependentOn;
            set => SetValue(ref _dependentOn, value);
        }

        public void Load(string str)
        {
            var item = JsonConvert.DeserializeObject<ChecklistItem>(str);
            IsChecked = item.IsChecked;
            Description = item.Description;
            if (item.TaskId.HasValue)
            {
                var idVal = item.TaskId.Value;
                App.Current.MainVm.Tasks.On(it => it.Id == idVal, it => DependentOn = it);
            }
        }

        public string Save()
        {
            return JsonConvert.SerializeObject(new ChecklistItem
            {
                TaskId = DependentOn?.Id,
                Description = Description,
                IsChecked = IsChecked
            });
        }
    }
}
