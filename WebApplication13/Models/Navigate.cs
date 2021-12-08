using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class Navigate
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Href { get; set; }

        public int Order { get; set; }

        [ForeignKey("Id")]
        public int? Parent_Id { get; set; }

        public ICollection<Navigate> Childs { get; set; }
    }
}
