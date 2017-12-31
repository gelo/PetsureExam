using System;
using System.Collections.Generic;
using PetSure.Core.Models;
using PetSure.Core.Services.Interfaces;
using PetSure.Core.Common;

namespace PetSure.Core.Services
{
    public class PetProfileService : IPetProfileService
    {
        public IEnumerable<PetProfile> GetAllPetProfile()
        {
            var results = new List<PetProfile>();

            var pet = new PetProfile
            {
                Id = new Guid("09fb999f-8955-4841-9cda-5ea9fd53093d"),
                Name = "Pixie",
                Description = "",
                Species = PetSpecies.Cat.ToString()
            };
            results.Add(pet);

            pet = new PetProfile
            {
                Id = new Guid("ce691289-6680-443c-8f83-b3b33a89ee18"),
                Name = "Rover",
                Description = "",
                Species = PetSpecies.Dog.ToString()
            };
            results.Add(pet);

            pet = new PetProfile
            {
                Id = new Guid("7028CEA6-5F49-4FB7-AA8B-3EFBFF9C2E09"),
                Name = "Fido",
                Description = "",
                Species = PetSpecies.Dog.ToString()
            };
            results.Add(pet);

            return results;

        }
    }
}
