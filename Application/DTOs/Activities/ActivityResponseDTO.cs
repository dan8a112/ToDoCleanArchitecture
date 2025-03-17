using Application.DTOs.ActivityTypes;
using Application.DTOs.Users;

namespace Application.DTOs.Activities
{
    public class ActivityResponseDTO
    {
        public DateTime CreationDate;
        public DateTime EndDate;
        public string? Description;
        public bool Completed;

        public int UserId;
        public int ActivityTypeId;

        public UserResponseDTO? UserResponseDTO;
        public ActivityTypeResponseDTO? ActivityTypeResponseDTO;
        public required List<Domain.Entities.Task> Tasks;
    }
}
