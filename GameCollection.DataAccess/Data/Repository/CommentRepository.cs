using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCollection.DataAccess.Data.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _db;

        public CommentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Comment Comment)
        {
            var objFromDb = _db.Comment.FirstOrDefault(s => s.Id == Comment.Id);

            objFromDb.GameId = Comment.GameId;
            objFromDb.CustomerId = Comment.CustomerId;
            objFromDb.DateCreated = DateTime.Now;
            objFromDb.FeedBack = Comment.FeedBack;

            _db.SaveChanges();
        }
    }
}
