using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WeCore.Api.Models
{
    public class User : IdentityUser
    {
        public bool IsActive { get; set; }

        // Admin Panel Management
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public UserRole Role { get; set; }
        
        // IWA Authentication
        public string Domain { get; set; }
        public string WindowsUsername { get; set; }
        
        // User Preferences
        public string Language { get; set; }
        public string TimeZone { get; set; }
        public bool EmailNotificationsEnabled { get; set; }
        
        // Kanban Related Properties
        public virtual ICollection<Board> OwnedBoards { get; set; }
        public virtual ICollection<BoardMember> BoardMemberships { get; set; }
        public virtual ICollection<Card> AssignedCards { get; set; }
        public virtual ICollection<CardActivity> Activities { get; set; }
        
        // Audit Fields
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }

        public User()
        {
            OwnedBoards = new HashSet<Board>();
            BoardMemberships = new HashSet<BoardMember>();
            AssignedCards = new HashSet<Card>();
            Activities = new HashSet<CardActivity>();
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }
    }

    public enum UserRole
    {
        User,
        BoardAdmin,
        SystemAdmin
    }
}