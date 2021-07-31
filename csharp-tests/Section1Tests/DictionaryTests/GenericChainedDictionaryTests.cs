using csharp.Section1.Dictionary;
using NUnit.Framework;

namespace csharp_tests.Section1Tests.DictionaryTests
{
    public class GenericChainedDictionaryTests
    {
        private GenericChainedDictionary<int, string> _map = new GenericChainedDictionary<int, string>();

        [Test]
        public void TestAdd()
        {
            _map.Add(1, "Steven");

            Assert.AreEqual(_map.Count(), 1);
        }
    }
}