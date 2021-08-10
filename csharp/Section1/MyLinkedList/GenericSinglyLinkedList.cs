using System;

namespace csharp.Section1.MyLinkedList
{
    public class GenericSinglyLinkedList<T> : IGenericList<T> where T : IComparable
    {
        private SinglyNode<T> _head;
        private SinglyNode<T> _tail;
        private int _size;

        public GenericSinglyLinkedList()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }

        public void AddFirst(T item)
        {
            SinglyNode<T> newNode = new SinglyNode<T>(item);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }

            _size++;
        }

        public void AddLast(T item)
        {
            SinglyNode<T> newNode = new SinglyNode<T>(item);
            if (_tail == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }

            _size++;
        }

        public int Count() => _size;

        public int IndexOf(T item)
        {
            SinglyNode<T> currentNode = _head;
            int index = 0;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(item) == 0)
                    return index;
                index++;

                currentNode = currentNode.Next;
            }

            return -1;
        }

        // Implemented as if we did not have the field for _size.
        // This uses the runner technique.
        /*
        
        return 3 last

        nB                
                        nA
        (1) -> (2) -> (3) -> (4)

            k = 3
            i = 3


        Time O(n)
        */
        public T KthFromEnd(int k)
        {
            if (_head == null)
                throw new Exception($"Linked list is not long enough to return {k} last.");
            SinglyNode<T> nodeBehind = _head;
            SinglyNode<T> nodeAhead = _head;

            int i = 1;
            while (i < k && nodeAhead.Next != null)
            {
                if (nodeAhead.Next == null)
                    throw new Exception($"Linked list is not long enough to return {k} last.");
                nodeAhead = nodeAhead.Next;
                i++;
            }

            while (nodeAhead.Next != null)
            {
                nodeBehind = nodeBehind.Next;
                nodeAhead = nodeAhead.Next;
            }

            return nodeBehind.Value;
        }

        public T RemoveFirst()
        {
            if (_head == null)
                throw new Exception("List is empty. Cannot remove items");

            T valueToRemove = _head.Value;
            if (_head == _tail)
            {

                _head = null;
                _tail = null;
            }
            else
            {
                SinglyNode<T> secondNode = _head.Next;
                _head = secondNode;
            }

            _size--;
            return valueToRemove;
        }

        // Implementated as if did not have access to _size field.
        // Use the runner technique.
        /*

        ()
            throw an exception
        
        (1)
            get the value,
            valueToRemove = 1
            head and tail make null
            size decrement
            return valueToRemove


        nodeB           nodeA
        (1)         ->  (2)

            continue looping until nodeA.next is null,
            then nodeA will be the last node 
            valueToRemove = 2
            nodeB.next = null
            make tail reference nodeB
            size decrement
            return valueToRemove
    
        */
        public T RemoveLast()
        {
            if (_head == null)
                throw new Exception("List is empty. Cannot remove items");

            T valueToRemove = default(T);
            if (_head.Next == null)
            {
                valueToRemove = _head.Value;
                _head = null;
                _tail = null;
            }
            else
            {
                SinglyNode<T> nodeBehind = _head;
                SinglyNode<T> nodeAhead = _head.Next;

                while (nodeAhead.Next != null)
                {
                    nodeBehind = nodeBehind.Next;
                    nodeAhead = nodeAhead.Next;
                }

                valueToRemove = nodeAhead.Value;
                nodeBehind.Next = null;
                _tail = nodeBehind;
            }
            _size--;
            return valueToRemove;
        }

        /*
        head                   tail
        (1) -> (2) -> (3) -> (4)

    nB
        nA      
            temp
        (1) -> (2) -> (3) -> (4)

            nA.Next = nB;
            nB = nA
            nA = temp    

        nB
                nA      
                     temp
        (1) -> (2) -> (3) -> (4)

            // so get a reference to nA.Next
            // so that we don't loose the other half of the linked list

            nA.Next = nB

         nB
                nA      
                     temp
        (1) <- (2) -> (3) -> (4)

            nB = nA
            nA = temp

                nB
                      nA      
        (1) <- (2) -> (3) -> (4)

                nB
                      nA
                              temp  
        (1) <- (2) <- (3) -> (4)

            nA.Next = nB

            nB = nA
            nA = temp

                        nB
                              nA  
        (1) <- (2) <- (3) <- (4)

            nA.Next = nB
            nB = nA
            nA = temp


        so now make 
        _head = nB

        */
        public void Reverse()
        {
            if (_head == null)
                throw new Exception("Cannot reverse an empty linked list");

            if (_head.Next == null)
                return;

            SinglyNode<T> nodeBehind = null;
            SinglyNode<T> nodeAhead = _head.Next;

            while (nodeAhead != null)
            {
                SinglyNode<T> next = nodeAhead.Next;
                nodeAhead.Next = nodeBehind;
                nodeBehind = nodeAhead;
                nodeAhead = next;
            }

            SinglyNode<T> temp = _head;
            _tail = _head;
            _head = _tail;
        }
    }
}