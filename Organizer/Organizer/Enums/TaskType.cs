using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Organizer.Enums
{
    public enum TaskType
    {
        [Description("Undefined")]
        None,
        [Description("A task with fixed due date (e. g. meeting or another appointed event)")]
        Fixed,
        [Description("A task with a deadline (e. g. finish an article until some date)")]
        Deadline,
        [Description("A continuous task (e. g. daily sport or write some text for a book)")]
        Ongoing
    }
}
