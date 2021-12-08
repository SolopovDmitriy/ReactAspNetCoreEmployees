using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class Option
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Relation { get; set; }

        public int Order { get; set; }

        [DefaultValue(false)]
        public bool isSystem { get; set; }
    }
}
