using Adventure2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public interface ILocationProvider
    {
        bool ExistsLocation(Room id);
        Location GetLocation(Room id);
        List<Connection> GetConnectionsFrom(Room id);
        List<Connection> GetConnectionsTo(Room id);
        bool IsNavigationLegitimate(Room from, Room to, GameState state);
    }
}
