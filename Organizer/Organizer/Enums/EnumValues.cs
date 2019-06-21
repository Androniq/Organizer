namespace Organizer.Enums
{
    public static class EnumValues
    {
        public static TaskType[] TaskTypes { get; } = { TaskType.Fixed, TaskType.Deadline, TaskType.Ongoing };

        public static TaskPriority[] TaskPriorities { get; } =
        {
            TaskPriority.Urgent, TaskPriority.High, TaskPriority.Average, TaskPriority.Low, TaskPriority.Optional
        };
    }
}
