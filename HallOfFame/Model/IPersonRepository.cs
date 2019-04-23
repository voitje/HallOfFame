using System;
using System.Collections.Generic;

namespace HallOfFame.Model
{
    public interface IPersonRepository
    {
        Person Add(Person person);
        Person Get(Guid id);
        IEnumerable<Person> GetAll();
        void Remove(Guid id);
        bool Update(Person person);
    }
}