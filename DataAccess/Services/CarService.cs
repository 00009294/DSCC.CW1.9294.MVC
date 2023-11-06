using DataAccess.DataContext;
using DataAccess.Entities;
using DataAccess.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext appDbContext;

        public CarService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IList<Car> GetAll()
        {
            var listCar = this.appDbContext.Cars.ToList();
            if (listCar != null)
            {
                return listCar;
            }

            return null;
        }

        public Car GetById(int id)
        {
            var selectedCar = this.appDbContext.Cars.FirstOrDefault(x => x.Id == id);

            if (selectedCar != null)
            {
                return selectedCar;
            }

            return null;
        }

        public bool Create(Car car)
        {
            this.appDbContext.Cars.Add(car);

            return this.appDbContext.SaveChanges() > 0;
        }

        public bool Update(Car car)
        {
            this.appDbContext.Cars.Update(car);

            return this.appDbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var selectedCar = this.appDbContext.Cars.FirstOrDefault(x => x.Id == id);
            if (selectedCar != null)
            {
                this.appDbContext.Cars.Remove(selectedCar);
            }
            else return false;

            return this.appDbContext.SaveChanges() > 0;
        }
    }
}