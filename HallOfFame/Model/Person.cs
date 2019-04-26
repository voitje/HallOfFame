using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HallOfFame.Model
{
    public class Person
    {
        #region Properties

        public long Id { set; get; }

        public string Name
        {
            set
            {
                var regex = new Regex(@"^[А-ЯЁ][а-яё]");
                var match = regex.Match(value);
                if (match.Success)
                {
                    Name = value;
                }
            }
            get => Name;
        }

        public string DisplayName { set; get; }

        public List<Skill> Skills { set; get; }

        #endregion

        #region Constructor

        public Person(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }

        private Person()
        {
        }

        #endregion
    }
}