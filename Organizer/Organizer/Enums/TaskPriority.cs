using System.ComponentModel;

namespace Organizer.Enums
{
    public enum TaskPriority
    {
        None,
        [Description("Urgent")]
        Urgent,
        [Description("High")]
        High,
        [Description("Average")]
        Average,
        [Description("Low")]
        Low,
        [Description("Optional")]
        Optional
    }
}