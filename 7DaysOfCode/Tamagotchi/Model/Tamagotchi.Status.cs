using System;
using System.Runtime.CompilerServices;
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
    

        public void Status()
        {
            Food = 10;
            Humor =  5;
            Energy = 5;

        }

        public void ToFeed()
        {
            // Alimentar ++
            // Energia --

            checkFood();
        }

        public void ToPlay()
        {
            // Humor ++
            // Energia --
            // Alimentar -

            checkHumor();
        }

        public void Rest()
        {
            // Energy ++
            // Humor --
            // Food --

            checkEnergy();
        }

        private void checkFood()
        {
            if(Food <= 5){
                Console.WriteLine("[Alimentar]: Estou ficando com Fome");
            }
            else if (Food < 3){
                Console.WriteLine("[Alimentar]: Quero Coomer");
            }
            else{
                Console.WriteLine("Que gostoso");   
            } 
        }

        private void checkEnergy()
        {
            if (Energy <= 3){
                Console.WriteLine("[Energia]: Estou ficando Cansando");  
            } 
        }

        private void checkHumor()
        {
            if(Humor <= 3){

                Console.WriteLine("[Humor]: Brinque comigo");
            } else {
                Console.WriteLine("[Humor]: Que divertido");
            }
        }

    }    
}