﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Inspirator.Model.Entities
{
    public class Option :BaseEntity 
    {
        [Required]
        public string Summary { get; set; }
        [Required]
        public int Index { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Option(string summary, int index)
        {
            Summary = summary;
            Index = index;
        }
    }
}
