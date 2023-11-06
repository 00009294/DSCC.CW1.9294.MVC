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
    public class OwnerService : IOwnerService
    {
        private readonly AppDbContext appDbContext;

        public OwnerService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IList<Owner> GetAll()
        {
            var listOwner = this.appDbContext.Owners.ToList();
            if (listOwner != null)
            {
                return listOwner;
            }

            return null;
        }

        public Owner GetById(int id)
        {
            var selectedOwner = this.appDbContext.Owners.FirstOrDefault(x => x.Id == id);

            if (selectedOwner != null)
            {
                return selectedOwner;
            }

            return null;
        }

        public bool Create(Owner owner)
        {
            var carId = owner.CarId;
            var res = this.appDbContext.Cars.FirstOrDefault(c => c.Id == carId);
            if (res != null)
            {
                this.appDbContext.Owners.Add(owner);
                return this.appDbContext.SaveChanges() > 0;
            }

            return false;
        }

        public bool Update(Owner owner)
        {
            this.appDbContext.Owners.Update(owner);

            return this.appDbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var selectedOwner = this.appDbContext.Owners.FirstOrDefault(x => x.Id == id);
            if (selectedOwner != null)
            {
                this.appDbContext.Owners.Remove(selectedOwner);
            }
            else return false;

            return this.appDbContext.SaveChanges() > 0;
        }
    }
}