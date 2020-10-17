using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCollection.DataAccess.Data.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        private readonly ApplicationDbContext _db;

        public GameRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Game Game)
        {
            var objFromDb = _db.Game.FirstOrDefault(s => s.Id == Game.Id);

            objFromDb.Name = Game.Name;
            objFromDb.DisplayOrder = Game.DisplayOrder;
            objFromDb.Image = Game.Image;
            objFromDb.Description = Game.Description;

            _db.SaveChanges();
        }
    }
}
