using System;
using Microsoft.VisualBasic;
using Tamagotchi.Model;
using Tamagotchi.Service;

namespace Tamagotchi.Controller
{
    public class TamagotchiController
    {
        private TamagotchiView tamagotchiView { get; set; }
        private PokemonApiRequest pokemonApiRequest { get; set; }
        private List<TamagotchiSpecies> availableMascot { get; set; }
        private List<TamagotchiStatus> adoptedSpecies { get; set; }

public TamagotchiController()
        {
            tamagotchiView = new TamagotchiView();
            pokemonApiRequest = new PokemonApiRequest();
            adoptedSpecies = new List<TamagotchiStatus>();

            InitializeAsync().Wait();
        }

        public async Task InitializeAsync()
        {
            availableMascot = await pokemonApiRequest.GetAvailableSpecies();
        }

        public void Play()
        {

            tamagotchiView.WelcomeMessage();

            while (true)
            {
                tamagotchiView.MainMenu();
                int choicePlayer = tamagotchiView.GetPlayerChoise(3);

                switch (choicePlayer)
                {
                    case 1:
                        while(true){
                            tamagotchiView.AdoptionMenu();
                            choicePlayer = tamagotchiView.GetPlayerChoise(3);

                            switch (choicePlayer)
                            {
                                case 1:
                                    tamagotchiView.GetavailableMascot(availableMascot);
                                    int choiceMascotAvailable = tamagotchiView.GetMascotChosen(availableMascot);
                                    TamagotchiAbility ability = pokemonApiRequest.GetSpeciesAbility(availableMascot[choiceMascotAvailable]);
                                    tamagotchiView.MascotAbilities(ability);
                                    break;
                                case 2:
                                    tamagotchiView.GetavailableMascot(availableMascot);
                                    choiceMascotAvailable = tamagotchiView.GetMascotChosen(availableMascot);
                                    ability = pokemonApiRequest.GetSpeciesAbility(availableMascot[choiceMascotAvailable]);
                                    tamagotchiView.MascotAbilities(ability);
                                    Console.Write("\n Confirme a adoção do mascote! (sim/nao): ");

                                    var confirmAdoption = Console.ReadLine().ToLower().Substring(0, 3) == "sim";

                                        if (confirmAdoption){

                                            if (choiceMascotAvailable >= 0 && choiceMascotAvailable < availableMascot.Count)
                                            {
                                                var tamagotchi = new TamagotchiStatus();
                                                tamagotchi.UpdateProperties(ability);
                                                adoptedSpecies.Add(tamagotchi);
                                                Console.WriteLine("\n\nParabéns! Você adotou um " + ability.Name + "!");

                                                availableMascot.RemoveAt(choiceMascotAvailable);
                                            } 
                                        }
                                    break;

                                case 3: break;
                            }
                            if(choicePlayer == 3)
                                break;     
                        }
                        break;
                    case 2:
                        tamagotchiView.AdoptMascot(adoptedSpecies);

                        if(adoptedSpecies.Count == 0)
                            break;

                        Console.Write("\n Verifique como seu Mascote está (sim/nao): ");                
                        var checkStatus = Console.ReadLine().ToLower().Substring(0, 3) == "sim";

                        if(checkStatus)
                        {
                            Console.Write("Escolha uma Mascote adotado: ");

                            int chooseAdopetMascot = tamagotchiView.GetPlayerChoise(adoptedSpecies.Count) - 1;
                            TamagotchiStatus getChooseMascot = adoptedSpecies[chooseAdopetMascot];

                            while(true)
                            {
                                tamagotchiView.InteractionMenu(getChooseMascot);
                                choicePlayer = tamagotchiView.GetPlayerChoise(5);

                                    switch(choicePlayer)
                                    {
                                        case 1: getChooseMascot.Status(); break;
                                        case 2: getChooseMascot.ToFeed(); break;
                                        case 3: getChooseMascot.ToPlay(); break;
                                        case 4: getChooseMascot.Rest(); break;
                                    }

                                if(choicePlayer == 5)
                                    break;
                            }
                        }
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n Obrigado por jogar ;)"); 
                        return;
                }
            }
        }
    }
}