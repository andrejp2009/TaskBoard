using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskBoard.Models
{
    public class Label
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        
        public ICollection<CardLabel> CardLabels { get; set; }
    }
    }