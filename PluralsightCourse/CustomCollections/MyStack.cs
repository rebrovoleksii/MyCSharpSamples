using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.CustomCollections
{
    public class MyStack<T>
    {
        public int Count { get; set; }
        internal StackItem<T> TopStackItem { get; private set; }
      
        public MyStack()
        {
            TopStackItem = null;
        }

        public void Push(T value)
        {
            if (TopStackItem == null)
            {
                TopStackItem = new StackItem<T>(value, null);
            }
            else
            {
                var newStackItem = new StackItem<T>(value, TopStackItem);
                TopStackItem = newStackItem;
            }
            Count++;
        }

        public T Peek()
        {
            return TopStackItem.Value;
        }

        public T Pop()
        {
            if (TopStackItem != null)
            {
                var result = TopStackItem.Value;
                TopStackItem = TopStackItem.Next as StackItem<T>;
                Count--;
                return result;
            }
            else
                throw new Exception();
        }
    }

    public class StackItem<T>
    {
        public T Value { get; set; }
        internal object Next { get; set; }

        internal StackItem(T value, object next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
