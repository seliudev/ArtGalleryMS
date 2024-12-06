using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
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
                return Error("Artists with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Artists.Add(record);
            _db.SaveChanges(); //commit to database
            return Success("Artists created successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Artists.Include(a => a.Artworks).SingleOrDefault(a => a.Id == id); //eager loading
            if (entity == null)
                return Error("Artists can't be found!");
            if( entity.Artworks.Any()) //Count > 0
                return Error("Artists has relational artworks!");
            _db.Artists.Remove(entity);
            _db.SaveChanges(); //commit to database
            return Success("Artists deleted successfully.");
        }

        public IQueryable<ArtistsModel> Query()
        {
            return _db.Artists.OrderBy(a => a.Name).Select(a => new ArtistsModel() { Record = a });
        }

        public ServiceBase Update(Artists record)
        {
            if (_db.Artists.Any(a => a.Id != record.Id && a.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Artists with the same name exists!");
            var entity = _db.Artists.SingleOrDefault(a => a.Id == record.Id);
            if(entity == null)
                return Error("Artists can't be found!");
            entity.Name = record.Name?.Trim();
            _db.Artists.Update(entity);
            _db.SaveChanges(); //commit to database
            return Success("Artists updated successfully.");
        }
    }
}
