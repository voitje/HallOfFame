using System.Collections.Generic;
using System.Linq;
using HallOfFame.Model;
using Microsoft.AspNetCore.Mvc;

namespace HallOfFame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        #region Fields

        #region Private fields

        private readonly AppDatabaseContext _context;

        #endregion

        #endregion

        #region Constructor

        public PersonController(AppDatabaseContext context)
        {
            _context = context;
        }

        #endregion

        #region Public methods

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var persons = _context.Persons;
            return persons;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Person Get(long id)
        {
            return _context.Persons.Find(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(Person person, List<Skill> skills)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            for (var i = 0; i < skills.Count; i++)
            {
                skills[i].PersonId = person.Id;
                _context.Skills.Add(skills[i]);
            }

            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(long id, Person newPerson)
        {
            var person = _context.Persons.Find(id);
            person.Name = newPerson.Name;
            person.DisplayName = newPerson.DisplayName;
            person.Skills = newPerson.Skills;
            for (var i = 0; i < newPerson.Skills.Count; i++)
            {
                if (newPerson.Skills[i].Name == person.Skills[i].Name)
                {
                    if (newPerson.Skills[i].Level != person.Skills[i].Level)
                    {
                        person.Skills[i].Level = newPerson.Skills[i].Level;
                    }
                }
                else
                {
                    person.Skills.Add(person.Skills[i]);
                }
            }

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            var person = _context.Persons.Find(id);
            var skill = _context.Skills.Where(u => u.PersonId == id).ToList();
            _context.Persons.Remove(person);
            for (var i = 0; i < skill.Count(); i++)
            {
                _context.Skills.Remove(skill[i]);
            }

            _context.SaveChanges();
        }

        #endregion
    }
}