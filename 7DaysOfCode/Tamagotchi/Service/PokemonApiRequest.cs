using System;
using Newtonsoft.Json;
using RestSharp;

namespace Tmagotchi
{
    public class PokemonApiRequest
    {
        public void GetSpeciesDetails()
        {
                // Obter as características do Pokémon escolhido
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/");
            var request = new RestRequest("",Method.Get);
            var response = client.Execute(request);


            if(response.StatusCode == System.Net.HttpStatusCode.OK){

                Console.WriteLine(response.Content);

            } else {

                Console.WriteLine(response.ErrorException);
            }
            Console.ReadKey();   
        }
    }
}