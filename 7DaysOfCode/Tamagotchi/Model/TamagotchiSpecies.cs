using System;
using Tamagotchi.Model;

namespace Tamagotchi.Model
{
    public class TamagotchiSpecies
    {
        public string Name {get; set;}
        public string Url {get; set;}

        public TamagotchiSpecies(string name, string url)
        {
            Name = name;
            Url = url;
        }

    }
}