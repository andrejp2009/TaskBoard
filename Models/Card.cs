using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskBoard.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        
        public int ListId { get; set; }
        public List List { get; set; }
        
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CardLabel> CardLabels { get; set; }
    }
}