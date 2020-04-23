using Adventure2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public class GameService
    {
        private readonly ISessionStorage<GameState> _ss;
        private readonly ILocationProvider _lp;
        private const string KEY = "AMAZINGADVENTURE";
        private const Room START_ROOM = Room.Start;
        public GameState State { get; private set; }
        public Location Location { get { return _lp.GetLocation(State.Location); } }
        public List<Connection> Targets { get { return _lp.GetConnectionsFrom(State.Location); } }

        public GameService(ISessionStorage<GameState> ss, ILocationProvider lp)
        {
            _ss = ss;
            _lp = lp;
            State = new GameState();
        }

        public void Start()
        {
            State = new GameState { HP = 10, Location = START_ROOM };
            Store();
        }

        public void FetchData()
        {
            State = _ss.LoadOrCreate(KEY);
        }

        public void Store()
        {
            _ss.Save(KEY, State);
        }
    }
}
