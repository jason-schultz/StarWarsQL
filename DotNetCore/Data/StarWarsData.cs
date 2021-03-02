using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartWarsQL.DotNetCore.Data.Interfaces;
using StartWarsQL.DotNetCore.Entities;


namespace StartWarsQL.DotNetCore.Data
{
    public class StarWarsData : IStarWarsData
    {
        private readonly List<Human> _humans = new List<Human>();
        private readonly List<Droid> _droids = new List<Droid>();

        public StarWarsData()
        {
            _humans.Add(new Human
            {
                Id = "1",
                Name = "Luke",
                Friends = new[] { "3", "4" },
                AppearsIn = new[] { 4, 5, 6 },
                HomePlanet = "Tatooine"
            });
            _humans.Add(new Human
            {
                Id = "2",
                Name = "Vader",
                AppearsIn = new[] { 4, 5, 6 },
                HomePlanet = "Tatooine"
            });

            _droids.Add(new Droid
            {
                Id = "3",
                Name = "R2-D2",
                Friends = new[] { "1", "4" },
                AppearsIn = new[] { 4, 5, 6 },
                PrimaryFunction = "Astromech"
            });
            _droids.Add(new Droid
            {
                Id = "4",
                Name = "C-3PO",
                AppearsIn = new[] { 4, 5, 6 },
                PrimaryFunction = "Protocol"
            });
        }

        public IEnumerable<StarWarsCharacter> GetHumans()
        {
            return _humans;
        }

        public IEnumerable<StarWarsCharacter> GetDroids()
        {
            return _droids;
        }

        public Human GetHumanById(string id) 
        {
            return _humans.FirstOrDefault(h => h.Id == id);
        }

        public Droid GetDroidById(string id) 
        {
            return _droids.FirstOrDefault(d => d.Id == id);
        }

        public Human AddHuman(Human human)
        {
            human.Id = Guid.NewGuid().ToString();
            _humans.Add(human);
            return human;
        }

        public Droid AddDroid(Droid droid)
        {
            droid.Id = Guid.NewGuid().ToString();
            _droids.Add(droid);
            return droid;
        }
    }
}