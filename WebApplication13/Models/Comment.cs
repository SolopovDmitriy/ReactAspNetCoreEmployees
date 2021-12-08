using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int Post_Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated{ get; set; }

        [DefaultValue(false)]
        public bool IsValid { get; set; }

        [DefaultValue(false)]
        public bool IsReview { get; set; }

        public int? Parent_Id { get; set; }
        
        public string VisitorName { get; set; }

        public string VisitorEmail { get; set; }

        public string VisitorAvatar { get; set; }

    }
}
