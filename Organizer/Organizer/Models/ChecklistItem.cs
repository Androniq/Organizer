using System;
using System.Collections.Generic;
using System.Text;

namespace Organizer.Models
{
    public class ChecklistItem
    {
        public bool IsChecked { get; set; }

        public int? TaskId { get; set; }

        public string Description { get; set; }
    }
}
