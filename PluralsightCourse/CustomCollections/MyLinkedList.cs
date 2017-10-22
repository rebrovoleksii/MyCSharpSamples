using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.CustomCollections
{
    public class MyLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _current;

        public MyLinkedList()
        {
            _head = null;
            _current = null;
        }

        public void AddLastNode(T value)
        {
            if (_head == null)
            {
                _head = new Node<T>(value, null);
                _current = _head;
            }
            else
            {
                var newNode = new Node<T>(value, null);
                _current.Next = newNode;
                _current = newNode;
            }
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        internal object Next { get; set; }

        internal Node()
        { }

        internal Node(T value, object next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
