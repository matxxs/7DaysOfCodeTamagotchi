using System;
using Tamagotchi.Model;

namespace Tamagotchi.Model
{
        public class TamagotchiApiResult
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<TamagotchiSpecies> Results { get; set; }
    }
}