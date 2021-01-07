using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPerros.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Thumbnail { get; set; }
        public PostDetail PostDetail { get; set; }

        public Post()
        {
            PostId = 0;
            Thumbnail = string.Empty;
        }
    }
}
