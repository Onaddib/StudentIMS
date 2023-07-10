using DataAccess.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentDbContext _db;

        public UnitOfWork(StudentDbContext db)
        {
            _db = db;
        }

        public IStudentRepository StudentRepository { get; set; }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
