using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        void Save();

        void Update(Student obj);

       

    }
}
