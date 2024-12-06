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
    //Way 1:
    //public interface IArtworksService
    //{
    //    //public IQueryable<ArtworksModel> Query();
    //    //public ServiceBase Create(Artworks record);
    //    //public ServiceBase Update(Artworks record);
    //    //public ServiceBase Delete(int id);
    //}
    //public class ArtworksService : ServiceBase, IArtworksService

    //Way 2:
    public class ArtworksService : ServiceBase, IService<Artworks, ArtworksModel>
    {
        public ArtworksService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Artworks record)
        {
            if (_db.Artworks.Any(w => w.Title.ToLower() == record.Title.ToLower().Trim() && w.Description.ToLower() == record.Description.ToLower()))
                return Error("Artworks with the same name and description exist!");
            record.Title = record.Title?.Trim();
            _db.Artworks.Add(record);
        }

        public ServiceBase Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ArtworksModel> Query()
        {
            return _db.Artworks.OrderByDescending(w => w.CreationDate).Select(w => new ArtworksModel() { Record = w });
        }

        public ServiceBase Update(Artworks record)
        {
            throw new NotImplementedException();
        }
    }
}
