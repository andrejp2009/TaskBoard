using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskBoard.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int BoardId { get; set; }
        public Board Board { get; set; }
        
        public ICollection<Card> Cards { get; set; }
    }

}