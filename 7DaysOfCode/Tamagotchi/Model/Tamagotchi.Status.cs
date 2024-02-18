using System;
using Tamagotchi.Model;

namespace Tamagotchi.Model
{
    public class TamagotchiStatus
    {
        public int Food     { get; set; }
        public int Humor    { get; set; }
        public int Sleep    { get; set; }
        public int Energy   { get; set; }
        public int Height   { get; set; }
        public int Weight   { get; set; } 
        public string Name  { get; set; }
    }
}