using System;

namespace PetSure.Core.Models
{
    public class PetProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Species { get; set; }
    }
}
