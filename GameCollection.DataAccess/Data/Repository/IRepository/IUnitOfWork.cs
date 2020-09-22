using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollection.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository Game { get; }
        IGameGenreRepository GameGenre { get; }
        ICustomerRepository Customer { get; }
        IPurchaseHistoryRepository PurchaseHistory { get; }
        ICommentRepository Comment { get; }
        IReviewerGameScoreRepository ReviewerGameScore { get; }
        void Save();
    }
}
