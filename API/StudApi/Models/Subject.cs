﻿using StudApi.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudApi.Models
{
    public class Subject : ICopyable<Subject>
    {
        [Required]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Room { get; set; }

        public void CopyProperties(Subject data)
        {
            Title = data.Title;
            Room = data.Room;
        }
    }
}
