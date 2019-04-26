using HallOfFame.Model;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        [TestCase("Igor", "NickName", ExpectedResult = "Igor")]
        public string Test1(string name, string displayName)
        {
            Person person = new Person(name, displayName);
            return person.Name;
        }
    }
}