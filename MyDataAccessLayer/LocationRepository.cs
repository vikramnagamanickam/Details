using CricketersDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer
{
    public interface ILocationRepository
    {
        public void InsertLocation(Location loc);
        public List<Location> GetAllLocation();
    }


    public class LocationRepository : ILocationRepository
    {

        LocationDbContext dbContext = null;
        public LocationRepository(LocationDbContext context)
        {
            dbContext = context;
        }

        public void InsertLocation(Location loc)
        {

            try
            {
                dbContext.Add(loc);
                dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<Location> GetAllLocation()
        {
            try
            {
                return dbContext.Location.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public Location GetLocationByName(string name)
        {
            try
            {
                return dbContext.Location.FirstOrDefault(X => X.Name == name);

            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}
