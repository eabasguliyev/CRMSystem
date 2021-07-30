using System;
using System.Collections.Generic;

namespace CrmSystem.Domain.Models
{
    public class Employee : BaseEmployee
    {
        public string Password { get; set; }

        public override void Update(BaseEmployee employee)
        {
            base.Update(employee);

            var e = employee as Employee;

            if (String.IsNullOrWhiteSpace(e.Password))
                return;

            Password = e.Password;
        }
    }
}