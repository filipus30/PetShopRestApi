using System;
using System.Collections.Generic;

namespace Petshop.Core.Entity
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerPhoneNr { get; set; }
        public List<Pet> PetsOwned { get; set; }

        

    }
}
