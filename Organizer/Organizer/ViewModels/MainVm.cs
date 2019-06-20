using Organizer.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ViewModels
{
    public class MainVm : ViewModelBase
    {
        private string _text;

        /// <summary>
        /// Gets or sets Text value.
        /// </summary>
        public string Text
        {
            get => _text;
            set => SetValue(ref _text, value, Save);
        }
        
        public async Task Load()
        {
            Text = await App.Current.Storage.ReadText();
        }

        public async void Save()
        {
            await App.Current.Storage.WriteText(Text);
        }
    }
}
