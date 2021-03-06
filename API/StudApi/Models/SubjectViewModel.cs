﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudApi.Models
{
    public class SubjectViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Room { get; set; }

        public List<Student> Students { get; set; }

    }
}
