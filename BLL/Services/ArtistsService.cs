using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IArtistsService
    {
        public IQueryable<ArtistsModel> Query();

        public ServiceBase Create(Artists record);
        public ServiceBase Update(Artists record);
        public ServiceBase Delete(int id);
    }

    public class ArtistsService : ServiceBase, IArtistsService
    {
        public ArtistsService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Artists record)
        {
            if (_db.Artists.Any(a => a.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Species with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Artists.Add(record);
            _db.SaveChanges(); //commit to database
            return Success("Artists created successfully.");
        }

        public ServiceBase Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ArtistsModel> Query()
        {
            return _db.Artists.OrderBy(a => a.Name).Select(a => new ArtistsModel() { Record = a });
        }

        public ServiceBase Update(Artists record)
        {
            throw new NotImplementedException();
        }
    }
}
