using GameCollection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollection.DataAccess.Data.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer Customer);
    }
}
