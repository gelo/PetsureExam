using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetSure.Core.Services;
using PetSure.Core.Services.Interfaces;
using PetSure.Core.Models;
using System.Collections.Generic;

namespace PetSure.Core.UnitTests
{
    [TestClass]
    public class PetProfileUnitTest
    {
        IPetProfileService petProfileService = new PetProfileService();

        [TestMethod]
        public void ShouldReturnListOfPets()
        {
            var results = petProfileService.GetAllPetProfile();

            Assert.IsNotNull(results);
        }
    }
}
