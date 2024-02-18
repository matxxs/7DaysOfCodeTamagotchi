using System;
using Tamagotchi.Model;
using Tamagotchi.Service;

namespace Tamagotchi.Controller
{
    public class TamagotchiController
    {
        private TamagotchiView tamagotchiView { get; set; }
        private PokemonApiRequest pokemonApiRequest { get; set; }
        private List<TamagotchiSpecies> availableMascot { get; set; }
        private List<TamagotchiAbility> adoptedSpecies { get; set; }

        public TamagotchiController()
        {
            tamagotchiView = new TamagotchiView();
            pokemonApiRequest = new PokemonApiRequest();
            availableMascot = pokemonApiRequest.GetAvailableSpecies();
            adoptedSpecies = new List<TamagotchiAbility>();
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
                                    int choiceMascot = tamagotchiView.GetMascotChosen(availableMascot);
                                    TamagotchiAbility ability = pokemonApiRequest.GetSpeciesAbility(availableMascot[choiceMascot]);
                                    tamagotchiView.MascotAbilities(ability);
                                    break;
                                case 2:
                                    tamagotchiView.GetavailableMascot(availableMascot);
                                    choiceMascot = tamagotchiView.GetMascotChosen(availableMascot);
                                    ability = pokemonApiRequest.GetSpeciesAbility(availableMascot[choiceMascot]);
                                    tamagotchiView.MascotAbilities(ability);
                                    Console.Write("\n Confirme a adoção do mascote! (sim/nao): ");
                                    var confirmAdoption = Console.ReadLine().ToLower().Substring(0, 3) == "sim";

                                        if (confirmAdoption){

                                            adoptedSpecies.Add(ability);
                                            Console.WriteLine("\n\nParabéns! Você adotou um " + ability.Name + "!"); 
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
                        break;
                    case 3:
                        break;
                    default: break;
                }
            }
        }
    }
}