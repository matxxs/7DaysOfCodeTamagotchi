using System;

namespace Tmagotchi 
{
    class Program
    {
        static void Main(string[] args)
        {
            PokemonApiRequest pokemonApiRequest = new PokemonApiRequest();
           pokemonApiRequest.GetSpeciesDetails();
        } 
    }
}