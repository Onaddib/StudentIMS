using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repository
{
    internal interface IUnitOfWork
    {


        IStudentRepository StudentRepository { get; set; }
        void Save();

    }


}
