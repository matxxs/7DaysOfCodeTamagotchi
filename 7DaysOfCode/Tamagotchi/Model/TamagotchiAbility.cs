using System;
using Tamagotchi.Model;

namespace Tamagotchi.Model
{
    public class TamagotchiAbility : TamagotchiSpecies
    {
        public List<AbilitiesClass> abilities { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

            public TamagotchiAbility(string name, string url, int height, int weight) : base(name, url)
            {
                Height = height;
                Weight = weight;
            }
    }

    public class AbilitiesClass
    {
        public TamagotchiAbility Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }
}