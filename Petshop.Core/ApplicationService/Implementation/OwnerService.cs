using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;

namespace Petshop.Core.ApplicationService.Implementation
{
    
        public class OwnerService : IOwnerService
        {
            private IOwnerRepository _ownerRepository;
            public OwnerService(IOwnerRepository ownerRepository)
            {
                _ownerRepository = ownerRepository;
            }

        public Owner GetOwnerById(int id)
        {
            Owner o = _ownerRepository.FindOwnerById(id);
            if (o == null)
            {
                throw new InvalidDataException("Wrong Id");
            }
            else
            {
                return o;
            }
        }

        public IEnumerable<Owner> GetOwners()
        {
           var v = _ownerRepository.ReadOwners();
             if (v == null)

                    throw new Exception("No Owners Found");
                else
                {
                    return v.ToList();
                }
        }


        public List<Owner> GetOwnersFiltered(FilterModel filter)
        {
            string value = filter.SearchValue;
            string filterby = filter.SearchTerm.ToLower();
            switch (filterby)
            {
                case "name":
                    var v = _ownerRepository.FindOwnersByName(value).ToList();
                    if (v.Count == 0)
                        throw new Exception(message: "no results found");
                    return v;
              
                default:
                    throw new InvalidDataException(message: "search for name");
            }
        }

        public Owner NewOwner(Owner o)
        {
            if (o.OwnerFirstName == null)
            {
                throw new InvalidDataException(message: "Name cannot be null");
            }
            else
            {
                _ownerRepository.AddOwner(o);
                return o;
            }
        }

        public Owner UpdateOwnerAddress(int id,string address)
        {
            var p = _ownerRepository.FindOwnerById(id);
            if (p == null)
            {
                throw new Exception(message: "Owner not found");
            }
            else
            {
                return _ownerRepository.UpdateOwnerAddress(id, address);
            }
        }


    }
    
}

