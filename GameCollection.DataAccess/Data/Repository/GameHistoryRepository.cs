using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCollection.DataAccess.Data.Repository
{
    public class GameHistoryRepository : Repository<GameHistory>, IGameHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public GameHistoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(GameHistory GameHistory)
        {
            var objFromDb = _db.GameHistory.FirstOrDefault(s => s.Id == GameHistory.Id);

            objFromDb.DateModified = DateTime.Now;

            _db.SaveChanges();
        }

    }
}
