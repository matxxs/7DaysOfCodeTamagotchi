using System;
using Tamagotchi.Model;

namespace Tamagotchi.Model
{
    public class TamagotchiView
    {
        public int GetPlayerChoise(int maxOption)
        {
            int choice;
            ConsoleColor corOriginal = Console.ForegroundColor;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxOption)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                HorizontalLines();
                Console.WriteLine($"\n ERROR : NÚMERO INVÁLIDO");
                Console.WriteLine($" Tente novamente um número 1 a {maxOption}.");
                HorizontalLines();
                Thread.Sleep(500);
                Console.ForegroundColor = corOriginal;
                Console.Write("\nDigite novamente: ");
            }
            return choice;
        }

        public void WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("\n================== TAMAGOCHI ==================\n "); ;
            Console.WriteLine("Bem-vindo ao jogo de adoção de mascotes!");
            Console.Write("\nPor favor, digite seu nome: ");
            var namePlayer = Console.ReadLine();
            Console.WriteLine($"Olá, {namePlayer}! Vamos começar!");
        }

        public void MainMenu()
        {
            HorizontalLines();
            Console.WriteLine("\n MENU PRINCIPAL \n");
            Console.WriteLine("1 - Adotar um mascote virtual");
            Console.WriteLine("2 - Ver seus mascotes");
            Console.WriteLine("3 - Sair");
            Console.Write("\n Escolha uma opção: ");
        }

        public void AdoptionMenu()
        {
            HorizontalLines();
            Console.WriteLine("\n MENU DE ADOÇÃO \n");
            Console.WriteLine("1 - Veja Mascote Disponiveis e Status");
            Console.WriteLine("2 - Adotar um Mascote");
            Console.WriteLine("3 - Sair");
            Console.Write("\n Escolha uma opção: ");
        }


        public void InteractionMenu(TamagotchiAbility specie)
        {
            HorizontalLines();
            Console.WriteLine($"\n Veja como {specie.Name} está \n ".ToUpper());
            Console.WriteLine($"1 - Cheque Status do {specie.Name}");
            Console.WriteLine($"2 - Alimentar {specie.Name}");
            Console.WriteLine($"3 - Brincar com {specie.Name}");
            Console.WriteLine("4 - Sair");
        }

        public void GetavailableMascot(List<TamagotchiSpecies> species)
        {
            HorizontalLines();
            Console.WriteLine("\n Mascote Disponíveis \n");

            for (int i = 0; i < species.Count; i++)
                Console.WriteLine($"{i + 1}. {species[i].Name}");
        }

        public int GetMascotChosen(List<TamagotchiSpecies> species)
        {
            int choice;

            while (true)
            {

                Console.Write("\n Escolha uma espécie pelo número (1-" + species.Count + "): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= species.Count)
                {

                    break;
                }
                Console.WriteLine("Escolha inválida.");
            }
            return choice - 1;
        }

        public void MascotAbilities(TamagotchiAbility specie)
        {
            Console.WriteLine($"\n Você escolheu {specie.Name}!");
            Console.WriteLine($"\n Detalhes:");
            Console.WriteLine($"- Peso: {specie.Weight}");
            Console.WriteLine($"- Altura: {specie.Height}");

            Console.Write($"- Habilidades: ");
            foreach (var abilityDetail in specie.abilities)
                Console.Write(abilityDetail.Ability.Name);

            Console.WriteLine(" ");
        }

        public void AdoptMascot(List<TamagotchiAbility> adoptedSpecies)
        {
            HorizontalLines();
            Console.WriteLine("\n MASCOTES ADOTADO \n");
            if (adoptedSpecies.Count == 0){

                Thread.Sleep(500);
                Console.WriteLine("Você ainda não obteve nenhum mascote");
            }
            else{
                
                for (int i = 0; i < adoptedSpecies.Count; i++)
                    Console.WriteLine($"{adoptedSpecies[i].Name}");
            }
        }

        private static void HorizontalLines()
        {
            for (int lines = 0; lines <= 46; lines++)
                Console.Write("-");

            Console.Write("\n");
        }
    }
}