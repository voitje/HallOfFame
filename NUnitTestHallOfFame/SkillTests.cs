using HallOfFame.Model;
using NUnit.Framework;

namespace Tests
{
    public class SkillTests
    {
        [Test]
        [TestCase("Igor", 10, 5, ExpectedResult = 10)]
        public byte Test1(string name, byte level, long personId)
        {
            Skill skill = new Skill(name, level, personId);
            return skill.Level;
        }
    }
}