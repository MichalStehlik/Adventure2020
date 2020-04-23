using Adventure2020.Models;
using Adventure2020.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public class LocationProvider : ILocationProvider
    {
        private Dictionary<Room, ILocation> _locations;
        private List<Connection> _map;

        public LocationProvider()
        {
            _locations = new Dictionary<Room, ILocation>();
            _map = new List<Connection>();
            _locations.Add(Room.Start, new Location { Title = "Start", Description = "This is where our story starts." }); // Game starts
            _locations.Add(Room.GameOver, new Location { Title = "Game Over", Description = "All worldly things will one day perish. You just did." }); // Game Over
            _locations.Add(Room.Hall, new Location { Title = "Hall", Description = "You stand in seemingly empty hall ..." });
            _locations.Add(Room.Library, new Location { Title = "Library", Description = "Library is in utterly desolate state ..." });
            _map.Add(new Connection(Room.Start, Room.Hall, "Go to hall"));
            _map.Add(new Connection(Room.Hall, Room.Library, "Visit Library", (gs) => { if (gs.HP > 10) return true; return false; }));
            _map.Add(new Connection(Room.Library, Room.Hall, "Return to hall"));
            _map.Add(new Connection(Room.Library, Room.GameOver, "Get eaten by Cthulhu"));
        }

        public bool ExistsLocation(Room id)
        {
            return _locations.ContainsKey(id);
        }

        public List<Connection> GetConnectionsFrom(Room id)
        {
            if (ExistsLocation(id))
            {
                return _map.Where(m => m.From == id).ToList();
            }
            throw new InvalidLocation();
        }

        public List<Connection> GetConnectionsTo(Room id)
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(Room id)
        {
            if (ExistsLocation(id))
            {
                return (Location)_locations[id];
            }
            throw new InvalidLocation();
        }

        public bool IsNavigationLegitimate(Room from, Room to, GameState state)
        {
            throw new NotImplementedException();
        }
    }
}
