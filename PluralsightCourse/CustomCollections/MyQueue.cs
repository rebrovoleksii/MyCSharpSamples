using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.CustomCollections
{
    public class MyQueue<T>
    {
        public int Count { get; set; }
        internal QueueItem<T> FirstInQueueItem { get; private set; } 
        internal QueueItem<T> LastInQueueItem { get; private set; }

        public MyQueue()
        {
            FirstInQueueItem = null;
        }

        public void Enqueue(T value)
        {
            if (FirstInQueueItem == null)
            {
                FirstInQueueItem = new QueueItem<T>(value, null);
                LastInQueueItem = FirstInQueueItem;
            }
            else
            {
                var newQueueItem = new QueueItem<T>(value, null);
                LastInQueueItem.Next = newQueueItem;
                LastInQueueItem = newQueueItem;                
            }
            Count++;
        }

        public T Peek()
        {
            return FirstInQueueItem.Value;
        }

        public T Dequeue()
        {
            if (FirstInQueueItem != null)
            {
                var result = FirstInQueueItem.Value;
                FirstInQueueItem = FirstInQueueItem.Next as QueueItem<T>;
                Count--;
                return result;
            }
            else
                throw new Exception();
        }
    }

    public class QueueItem<T>
    {
        public T Value { get; set; }
        internal object Next { get; set; }

        internal QueueItem(T value, object next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
