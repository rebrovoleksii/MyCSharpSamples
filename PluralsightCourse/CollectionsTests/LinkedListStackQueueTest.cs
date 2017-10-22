using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PluralSight.CustomCollections;

namespace PluralSight.Tests.Collections
{
    [TestClass]
    public class LinkedListStackQueueTest
    {
        [TestMethod]
        public void MyLinkedListTest()
        {
            MyLinkedList<string> linkedList = new MyLinkedList<string>();

            linkedList.AddLastNode("Alex");
            linkedList.AddLastNode("Tania");
            linkedList.AddLastNode("Ruslana");
        }

        [TestMethod]
        public void MyStackTest()
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(1221);

            var intialStackSize = stack.Count;
            for (int i = 1; i <= intialStackSize; i++)
            {
                Utils.WriteVariableToOutPut<int>(stack.Pop());
            }
        }

        [TestMethod]
        public void MyQueueTest()
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(10);
            queue.Enqueue(11);
        }
    }
}
