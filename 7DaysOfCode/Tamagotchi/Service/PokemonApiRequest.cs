using System;
using Tamagotchi.Model;
using Newtonsoft.Json;
using RestSharp;

namespace Tamagotchi.Service
{
    public class PokemonApiRequest
    {
        public async Task<List<TamagotchiSpecies>> GetAvailableSpecies()
        {
            var random = new Random();
            var randomSpecies = new List<TamagotchiSpecies>();
            int maxSpeciesView = 4;

            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/");

            for(int i = 0; i < maxSpeciesView; i++){
                
                int randomPokemonId = random.Next(1, 1000);
                var request = new RestRequest($"{randomPokemonId}", Method.Get);
                var response = await client.ExecuteAsync<TamagotchiSpecies>(request);

                     if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        CheckedAPI(response.StatusCode);
                    }

                var randomPokemon = response.Data;
                randomSpecies.Add(randomPokemon);
            }

            return randomSpecies;

            // var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/?limit=4");
            // var request = new RestRequest("",Method.Get);
            // var response = client.Execute(request);

            // if (response.StatusCode != System.Net.HttpStatusCode.OK){

            //     CheckedAPI(response.StatusCode);
            // }

            // var requestSpecies =  JsonConvert.DeserializeObject<TamagotchiApiResult>(response.Content);
            // return requestSpecies.Results;
     
        }

        public TamagotchiAbility GetSpeciesAbility(TamagotchiSpecies species)
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{species.Name}");
            var request = new RestRequest("",Method.Get);
            var response = client.Execute(request);    

            if (response.StatusCode != System.Net.HttpStatusCode.OK){

                CheckedAPI(response.StatusCode);
            }

            return JsonConvert.DeserializeObject<TamagotchiAbility>(response.Content);
        }

        private void  CheckedAPI(System.Net.HttpStatusCode statusCode)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine($"\n ERROR : STATUS " + statusCode );

            Console.WriteLine("____________________________________________________________ \n");

                switch (statusCode)
                {
                    case System.Net.HttpStatusCode.Unauthorized:
                        Console.WriteLine("A chave da API está desativada, incorreta ou não foi informada corretamente.");
                        break;
                    case System.Net.HttpStatusCode.	PaymentRequired:
                        Console.WriteLine("A chave da API está correta, porém a conta foi bloqueada por inadimplência.");
                        break;
                    case System.Net.HttpStatusCode.NotFound :
                        Console.WriteLine("O recurso solicitado ou o endpoint não foi encontrado.");
                        break;
                    case System.Net.HttpStatusCode.UnprocessableEntity:
                        Console.WriteLine("A requisição foi recebida com sucesso, porém contém parâmetros inválidos.");
                        break;
                    case System.Net.HttpStatusCode.TooManyRequests:
                        Console.WriteLine("O limite de requisições foi atingido.");
                        break;
                    case System.Net.HttpStatusCode.BadRequest:
                        Console.WriteLine("Não foi possível interpretar a requisição. Verifique a sintaxe das informações enviadas.");
                        break;
                    case System.Net.HttpStatusCode.InternalServerError:
                        Console.WriteLine("Ocorreu uma falha na API do Pokemon. Verifique se a API está funcionamento ");
                        break;
                    case 0: 
                        Console.WriteLine("Erro ao acessar a API: Sem conexão com a internet");
                        break;
                default:
                    Console.WriteLine("Erro ao acessar a API: " + statusCode);
                    break;  
                }

            Console.WriteLine("____________________________________________________________");
        }
    }
}