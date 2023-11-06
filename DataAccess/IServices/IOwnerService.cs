using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IServices
{
    public interface IOwnerService
    {
        IList<Owner> GetAll();

        Owner GetById(int id);

        bool Create(Owner Owner);

        bool Delete(int id);

        bool Update(Owner Owner);
    }
}