using csharp.Section1.Stack;
using NUnit.Framework;

namespace csharp_tests.Section1Tests.StackTests
{
    public class GenericArrayStackTests
    {
        private GenericArrayStack<int> _stack;

        [Test]
        public void Clear_WhenInvoked_ShouldResetToDefault()
        {
            _stack = new GenericArrayStack<int>();
            _stack.Push(1);

            _stack.Clear();

            Assert.AreEqual(_stack.Count(), 0);
        }

        [Test]
        public void IsEmpty_ContainsItems_ReturnsFalse()
        {
            _stack = new GenericArrayStack<int>();

            _stack.Push(1);

            Assert.IsFalse(_stack.IsEmpty());
        }

        [Test]
        public void IsEmpty_ContainsNoItems_ReturnsTrue()
        {
            _stack = new GenericArrayStack<int>();

            Assert.IsTrue(_stack.IsEmpty());
        }

        [Test]
        public void Peek_ContainsItem_ReturnsLastInsertedItem()
        {
            _stack = new GenericArrayStack<int>();
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            int latestInserted = _stack.Peek();

            Assert.AreEqual(latestInserted, 3);
        }

        [Test]
        public void Pop_ContainsItem_ReturnLastIntertedItem()
        {
            _stack = new GenericArrayStack<int>();
            _stack.Push(1);
            _stack.Push(2);

            int removedItem = _stack.Pop();

            Assert.AreEqual(removedItem, 2);
            Assert.AreEqual(_stack.Count(), 1);
        }
    }
}