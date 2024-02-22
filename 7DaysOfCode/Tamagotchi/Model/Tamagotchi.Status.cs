using System;
using Tamagotchi.Model;

namespace Tamagotchi.Model
{
    public class TamagotchiStatus
    {
        public int Food     { get; set; }
        public int Humor    { get; set; }
        public int Energy   { get; set; }
        public int Height   { get; set; }
        public int Weight   { get; set; } 
        public string? Name  { get; set; }
        public List<Ability> abilities {get; set;}

        public TamagotchiStatus()
        {
            var random = new Random();
            Food = random.Next(0, 10);
            Humor =  random.Next(0, 10);
            Energy = random.Next(0, 10);
        }

        public void UpdateProperties(TamagotchiAbility details)
        {
            Name = details.Name;
            Height = details.Height;
            Weight = details.Weight;
            abilities = details.abilities.Select(a => new Ability { Name = a.Ability.Name }).ToList();
        }

        public void Status()
        {
            Console.WriteLine();
            Console.WriteLine("[Alimentação]: " + Food);
            Console.WriteLine("[Humor]: " + Humor);
            Console.WriteLine("[Energia]: " + Energy);
        }

        public void ToFeed()
        {
            Food += 2;
            Energy -=  1;

            Console.WriteLine("\n Mascote Alimentado");
            CheckedStatus();
        }

        public void ToPlay()
        {
            Humor += 3;
            Energy -= 2;
            Food -= 1;

            Console.WriteLine("\n Mascote Feliz");
            CheckedStatus();
        }

        public void Rest()
        {
            Energy += 2;
            Humor -= 2;
            Food -= 1;

            Console.WriteLine("\n [ZZZZZ] Mascote dormindo");
            CheckedStatus();
        }

        private void CheckedStatus()
        {
            if(Food < 4 || Energy < 4 || Humor < 4)
            {
                Console.WriteLine("\n [ALERTA] \n");

                if(Food < 4)
                    Console.WriteLine("[Alimentar]: Quero Coomer");

                if(Energy < 4)
                    Console.WriteLine("[Energia]: Estou ficando Cansando");

                if(Humor < 4)
                    Console.WriteLine("[Humor]: Brinque comigo");
            }
        }

        public class Ability{
            
            public string Name {get; set; }
        }
    }    
}