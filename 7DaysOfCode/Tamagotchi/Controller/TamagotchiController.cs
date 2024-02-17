using System;
using Tamagotchi.Model;
using Tamagotchi.Service;

namespace Tamagotchi.Controller
{
    public class TamagotchiController
    {
        private PokemonApiRequest pokemonApiRequest { get; set; }
        private List<TamagotchiSpecies> availableMascot { get; set; }


        public TamagotchiController()
        {
            pokemonApiRequest = new PokemonApiRequest();
            availableMascot = pokemonApiRequest.GetAvailableSpecies();
        }

        public void Play()
        {
            Teste(availableMascot);

            int choice;

            while (true)
            {
                Console.Write("\n Escolha uma espécie pelo número (1-" + availableMascot.Count + "): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= availableMascot.Count)
                {
                    break;
                }
                Console.WriteLine("Escolha inválida.");
            }

            
            TamagotchiAbility ability = pokemonApiRequest.GetSpeciesAbility(availableMascot[choice - 1 ]);

            Menu(ability);


        }

        public void Teste(List<TamagotchiSpecies> species)
        {
            for (int i = 0; i < species.Count; i++)
                Console.WriteLine($@"{i + 1}. {species[i].Name}      | {species[i].Url}");        
        }

        public void Menu(TamagotchiAbility spceies)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Você escolheu {spceies.Name}!");
            Console.WriteLine($"Detalhes:");
            Console.WriteLine($"- Nome: {spceies.Name}");
            Console.WriteLine($"- Peso: {spceies.Weight}");
            Console.WriteLine($"- Altura: {spceies.Height}");
        }
    }
}