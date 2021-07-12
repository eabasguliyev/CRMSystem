﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CrmSystem.Domain.Models
{
    public class Contact:User
    {
        public string Title { get; set; }
        public Employee Owner { get; set; }
        public string Description { get; set; }
        public RecordDetail CreatedBy { get; set; }
        public RecordDetail ModifiedBy { get; set; }
        public List<Note> Notes { get; set; }
        public List<Task> Tasks { get; set; }
    }
}