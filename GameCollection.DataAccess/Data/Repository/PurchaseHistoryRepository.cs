using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCollection.DataAccess.Data.Repository
{
    public class PurchaseHistoryRepository : Repository<PurchaseHistory>, IPurchaseHistoryRepository
    {

        private readonly ApplicationDbContext _db;

        public PurchaseHistoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PurchaseHistory Purchase)
        {
            var objFromDb = _db.PurchaseHistory.FirstOrDefault(s => s.Id == Purchase.Id);

            objFromDb.GameId = Purchase.GameId;
            objFromDb.CustomerId = Purchase.CustomerId;
            objFromDb.DateCreated = DateTime.Now;
            objFromDb.Amount = Purchase.Amount;

            _db.SaveChanges();
        }
    }
}
