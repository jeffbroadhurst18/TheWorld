using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;
        private ILogger<WorldRepository> _logger;

        public WorldRepository(WorldContext context, ILogger<WorldRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddTrip(Trip trip)
        {
            _context.Add(trip);
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            try {
                _logger.LogInformation("Getting All Trips");
                return _context.Trips.OrderBy(t => t.DateCreated).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Trip>();
            }
        }

        public Trip GetTripByName(string tripName)
        {
            return _context.Trips.Include(x => x.Stops).First(x => x.Name == tripName);
        }

        public void  AddStop(string tripName, Stop newStop, string userName)
        {
            var trip = GetUserTripByName(tripName,userName);
            if (trip != null)
            {
                // Add the stop to the trip
                // Add the stop to stops
                trip.Stops.Add(newStop);
                _context.Stops.Add(newStop);
            }
            
        }

        public async Task<bool> SaveChangesAsync()
        {
            return(await _context.SaveChangesAsync() > 0);
        }

        public IEnumerable<Trip> GetTripsByUserName(string name)
        {
            return _context.Trips.Include(s => s.Stops).               
                Where(t => t.UserName == name).ToList().OrderBy(t => t.DateCreated);
        }

        public Trip GetUserTripByName(string tripName, string name)
        {
            return _context.Trips.Include(s => s.Stops).
                Where(t => t.Name == tripName && t.UserName == name).First();
        }
    }
}
