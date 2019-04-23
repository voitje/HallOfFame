using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace HallOfFame.Model
{
    public class Person
    {
        private long _id;

        private string _name;

        private string _displayName;

        private List<Skill> _skills;

        public long Id
        {
            set => _id = value;
            get => _id;
        }

        public string Name
        {
            set => _name = value;
            get => _name;
        }

        public string DisplayName
        {
            set => _displayName = value;
            get => _displayName;
        }

        public List<Skill> Skills
        {
            set => _skills = value;
            get => _skills;
        }

        public Person(string name, string displayName, List<Skill> skills)
        {
            Name = name;
            DisplayName = displayName;
            //Skills = new List<Skill>();
            Skills = skills;
        }
    }
}