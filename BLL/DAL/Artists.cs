using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Artists
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? Biography { get; set; }
        public bool IsRetired { get; set; }

        //1:N relationship

        public List<Artworks> Artworks { get; set; } = new List<Artworks>(); //navigational property
    }
}
