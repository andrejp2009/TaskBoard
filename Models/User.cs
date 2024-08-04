using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace TaskBoard.Models
{
    public class User : IdentityUser
    {
        public ICollection<BoardUser> BoardUsers { get; set; } = new List<BoardUser>();
    }
}