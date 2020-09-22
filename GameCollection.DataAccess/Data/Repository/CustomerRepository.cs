using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCollection.DataAccess.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Customer Customer)
        {
            var objFromDb = _db.Customer.FirstOrDefault(s => s.Id == Customer.Id);

            objFromDb.Name = Customer.Name;

            _db.SaveChanges();
        }
    }
}
