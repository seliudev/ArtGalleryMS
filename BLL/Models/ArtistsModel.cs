using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ArtistsModel
    {
        public Artists Record { get; set; }
        public string Name => Record.Name;
        public string Surname => Record.Surname;
        public string Email => Record.Email;
        public string Biography => Record.Biography;
        public bool IsRetired => Record.IsRetired;

    }
}
