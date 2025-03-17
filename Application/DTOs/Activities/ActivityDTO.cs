﻿using Domain.Entities;

namespace Application.DTOs.Activities
{
    public  class ActivityDTO
    {
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Completed { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int ActivityTypeId { get; set; }
        public ActivityType? ActivityType { get; set; }
    }
}
