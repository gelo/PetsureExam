using System;

namespace PetSure.Core.Common
{
    public enum PetSpecies
    {
        [System.Runtime.Serialization.EnumMember(Value = "Dog")]
        Dog = 0,

        [System.Runtime.Serialization.EnumMember(Value = "Cat")]
        Cat = 1,

    }
}
