using System;
using Tamagotchi.Model;
using Newtonsoft.Json;
using RestSharp;

namespace Tamagotchi.Service
{
    public class PokemonApiRequest
    {
        public List<TamagotchiSpecies> GetAvailableSpecies()
        {
                // Obter as características do Pokémon escolhido
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/?limit=4");
            var request = new RestRequest("",Method.Get);
            var response = client.Execute(request);

            var requestSpecies =  JsonConvert.DeserializeObject<TamagotchiApiResult>(response.Content);
            return requestSpecies.Results;
     
        }

        public TamagotchiAbility GetSpeciesAbility(TamagotchiSpecies species)
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{species.Name}");
            var request = new RestRequest("",Method.Get);
            var response = client.Execute(request);    

            return JsonConvert.DeserializeObject<TamagotchiAbility>(response.Content);
        }
    }
}