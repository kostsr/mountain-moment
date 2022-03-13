using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mountain_moment.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column("Album_id")]
        public int AlbumId { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}
