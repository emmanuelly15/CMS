﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public class GroupsListClass
    {
        [Key]
        public int Id { get; set; }
        
        public string Groups { get; set; }
    }
}
