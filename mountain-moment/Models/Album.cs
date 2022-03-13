using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mountain_moment.Models
{
    [Table("album")]
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
        public DateTime CDate { get; set; }
        public string Description { get; set; }
    }
}
