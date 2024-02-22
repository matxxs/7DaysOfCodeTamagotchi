using System;
using Tamagotchi.Controller;
using Tamagotchi.Model;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            TamagotchiController tamagotchiController = new TamagotchiController();  
            tamagotchiController.Play();  
        }
    }
}