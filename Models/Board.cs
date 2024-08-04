using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskBoard.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<BoardUser> BoardUsers { get; set; } = new List<BoardUser>();

        public ICollection<List> Lists { get; set; } = new List<List>();
    }
}
