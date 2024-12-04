using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Artworks
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }

        //N:1 relationship
        public int ArtistId { get; set; } //foreign key
        public Artists Artists { get; set; } //navigational property
    }
}
