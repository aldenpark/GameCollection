using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCollection.DataAccess.Data.Repository
{
    public class GameGenreRepository : Repository<GameGenre>, IGameGenreRepository
    {
        private readonly ApplicationDbContext _db;

        public GameGenreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetGameGenreListForDropDown()
        {
            return _db.GameGenre.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(GameGenre Genre)
        {
            var objFromDb = _db.Game.FirstOrDefault(s => s.Id == Genre.Id);

            objFromDb.Name = Genre.Name;

            _db.SaveChanges();
        }
    }
}
