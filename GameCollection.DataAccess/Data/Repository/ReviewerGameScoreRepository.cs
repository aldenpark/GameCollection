using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCollection.DataAccess.Data.Repository
{
    public class ReviewerGameScoreRepository : Repository<ReviewerGameScore>, IReviewerGameScoreRepository
    {

        private readonly ApplicationDbContext _db;

        public ReviewerGameScoreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ReviewerGameScore GameScore)
        {
            var objFromDb = _db.ReviewerGameScore.FirstOrDefault(s => s.Id == GameScore.Id);

            objFromDb.GameId = GameScore.GameId;
            objFromDb.CustomerId = GameScore.CustomerId;
            objFromDb.DateCreated = DateTime.Now;
            objFromDb.Score = GameScore.Score;

            _db.SaveChanges();
        }
    }
}
