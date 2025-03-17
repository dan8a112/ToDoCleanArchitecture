namespace Application.DTOs.Activities
{
    public class ActivityRequestDTO
    {
        public DateTime CreationDate;
        public DateTime EndDate;
        public required string Description;
        public bool Completed;

        public int UserId;
        public int ActivityTypeId;

        public required List<Domain.Entities.Task> Tasks;
    }
}
