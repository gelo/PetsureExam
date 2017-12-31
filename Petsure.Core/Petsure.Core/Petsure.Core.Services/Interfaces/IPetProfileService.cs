using System;
using System.Collections.Generic;
using PetSure.Core.Models;

namespace PetSure.Core.Services.Interfaces
{
    public interface IPetProfileService
    {
        IEnumerable<PetProfile> GetAllPetProfile();
    }
}
