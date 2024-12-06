using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IArtworksService
    {
        ////Way 1:
        //public IQueryable<ArtworksModel> Query();
        //public ServiceBase Create(Artworks record);
        //public ServiceBase Update(Artworks record);
        //public ServiceBase Delete(int id);
    }

    //Way 2:
    public class ArtworksService : ServiceBase, IService<Artworks, ArtworksModel>
    {
        public ArtworksService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Artworks record)
        {
            throw new NotImplementedException();
        }

        public ServiceBase Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ArtworksModel> Query()
        {
            throw new NotImplementedException();
        }

        public ServiceBase Update(Artworks record)
        {
            throw new NotImplementedException();
        }
    }
}
