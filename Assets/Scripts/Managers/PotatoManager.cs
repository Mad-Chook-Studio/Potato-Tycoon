using System.Collections.Generic;
using System.Linq;
using Potatoes;
using Seasons;
using UnityEngine;

namespace Managers
{
    public class PotatoManager
    {
        private readonly List<Potato> _potatoes;
    
        private SeasonManager _season;

        public PotatoManager() => _potatoes = Resources.LoadAll<Potato>("").ToList();
    
        public Potato GetPotato(string potatoName) => _potatoes.FirstOrDefault(potato => potato.PotatoName == potatoName);
    }
}