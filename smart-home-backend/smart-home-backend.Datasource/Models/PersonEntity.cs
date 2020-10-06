using System;
using System.Collections.Generic;
using System.Text;

namespace smart_home_backend.Datasource.Models
{
    public class PersonEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
    }
}
