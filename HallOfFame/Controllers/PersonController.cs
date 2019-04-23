using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HallOfFame.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HallOfFame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private AppDatabaseContext _context;

        public PersonController(AppDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var persons = _context.Persons.Select(u => u.Name).ToArray();
            return  persons;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(long id)
        {
            return _context.Persons.Find(id).Name;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(/*[FromBody]string valuelong id, */[FromBody]Person person/*, string displayName, List<Skill> skills*/)
        {
            /*Skill attentiveness = new Skill {Name = "attentiveness", Level = 5};
            List<Skill> skills = new List<Skill> {attentiveness};
            Person person = new Person(name, "voitje", skills);
            //person.Name = name;
            //person.DisplayName = "voitje";
            //person.Skills = skills;

            _context.Persons.Add(person);
            _context.Skills.Add(attentiveness);*/
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Person newPerson)
        {
            Person person = _context.Persons.Find(newPerson);

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            var person = _context.Persons.Find(id);
            _context.Persons.Remove(person);
        }
    }
}