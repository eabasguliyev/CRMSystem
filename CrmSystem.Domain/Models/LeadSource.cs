﻿namespace CrmSystem.Domain.Models
{
    public class LeadSource:DomainObject
    {
        public string Name { get; set; }
        public Company Company { get; set; }
    }
}