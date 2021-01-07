using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPerros.Models
{
    public class PostDetail
    {
        [Key]
        public int PostDetailId { get; set; }
        public string LongDescription { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string Categoria { get; set; }
        public string Race { get; set; }
        public float Price { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        List<string> Images { get; set; }

        public PostDetail()
        {
            PostDetailId = 0;
            LongDescription = string.Empty;
            Location = string.Empty;
            Gender = string.Empty;
            Race = string.Empty;
            Price = 0;
            PostId = 0;
            Images = new List<string>();
        }
    }
}
