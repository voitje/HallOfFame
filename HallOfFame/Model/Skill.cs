using System.ComponentModel.DataAnnotations;

namespace HallOfFame.Model
{
    public class Skill
    {
        #region Properties

        [Key]
        public long Id { set; get; }

        public string Name { set; get; }

        public byte Level
        {
            set
            {
                if (value <= 10)
                {
                    Level = value;
                }
            }
            get => Level;
        }

        public long PersonId { set; get; }

        #endregion

        #region Constructor

        public Skill(string name, byte level, long personId)
        {
            Name = name;
            Level = level;
            PersonId = personId;
        }

        #endregion
    }
}