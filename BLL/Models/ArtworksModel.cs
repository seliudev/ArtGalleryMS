using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ArtworksModel
    {
        public Artworks Record { get; set; }
        public string Title => Record.Title;
        public string Description => Record.Description;
        public double Price => Record.Price;
        public DateTime CreationDate => Record.CreationDate;
        public string Artists => Record.Artists?.Name;
    }
}
