using System;
using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Petshop.Core.DomainService
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(long id);
        void Add(User entity);
        void Edit(User entity);
        void Remove(long id);
    }
}
