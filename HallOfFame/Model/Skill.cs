using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace HallOfFame.Model
{
    public class Skill
    {
        private string _name;

        private byte _level;

        [Key]
        public string Name
        {
            set => _name = value;
            get => _name;
        }

        public byte Level
        {
            set => _level = value;
            get => _level;
        }
    }
}