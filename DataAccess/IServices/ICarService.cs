using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IServices
{
    public interface ICarService
    {
        IList<Car> GetAll();

        Car GetById(int id);

        bool Create(Car car);

        bool Delete(int id);

        bool Update(Car car);
    }
}