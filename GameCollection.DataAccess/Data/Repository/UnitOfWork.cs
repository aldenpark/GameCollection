using GameCollection.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollection.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IGameRepository Game { get; private set; }

        public IGameGenreRepository GameGenre { get; private set; }

        public ICustomerRepository Customer { get; private set; }

        public IPurchaseHistoryRepository PurchaseHistory { get; private set; }

        public ICommentRepository Comment { get; private set; }

        public IReviewerGameScoreRepository ReviewerGameScore { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
