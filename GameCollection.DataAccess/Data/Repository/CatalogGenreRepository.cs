using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCollection.DataAccess.Data.Repository
{
    public class CatalogGenreRepository : Repository<CatalogGenre>, ICatalogGenreRepository
    {
        private readonly ApplicationDbContext _db;

        public CatalogGenreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
