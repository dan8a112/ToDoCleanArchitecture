using Task = Domain.Entities.Task;

namespace Application.DTOs.Activities
{
    public class ActivityDTO
    {
        public DateTime CreationDate;
        public DateTime EndDate;
        public string Description = string.Empty;
        public bool Completed;

        public int UserId;
        public int ActivityTypeId;

        public required List<Task> Tasks;
    }
}
