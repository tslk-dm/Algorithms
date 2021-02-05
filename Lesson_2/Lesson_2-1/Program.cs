using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }
    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value); // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class LinkedList : ILinkedList
    {
        private int count = 0;

        private Node startNode;
        private Node endNode;
        
        public void AddNode(int value)
        {
            if (startNode == null)
            {
                startNode = new Node { Value = value };
                endNode = startNode;
            }
            else
            {
                var node = startNode;
                while (node.NextNode != null)
                {
                    node = node.NextNode;
                }
                var newNode = new Node { Value = value };
                node.NextNode = newNode;
                newNode.PrevNode = node;
                endNode = newNode;
            }
            count++;

        }

        public void AddNodeAfter(Node node, int value) //Что передать в параметре node в эту функцию??? Как указать этот элемент списка?
        {
            var newNode = new Node { Value = value };
            
            var nextNode = node.NextNode;
            node.NextNode = newNode;
            newNode.NextNode = nextNode;

            var prevNode = node.NextNode.NextNode.PrevNode;
            node.NextNode.NextNode.PrevNode = newNode;
            newNode.PrevNode = prevNode;

            count++;

        }

        public Node FindNode(int searchValue)
        {
            var currentNode = startNode;
            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    return currentNode;
                currentNode = currentNode.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            return count;
        }

        public void RemoveNode(int index)
        {
            if (index == 0)
            {
                var newStartNode = startNode.NextNode;
                startNode.NextNode = null;
                startNode = newStartNode;
                return;
            }
            if (index == count - 1)
            {
                var newEndNode = endNode.PrevNode;
                endNode.PrevNode = null;
                endNode = newEndNode;
                return;
            }
            int currentIndex = 0;
            var currentNode = startNode;
            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    currentNode.PrevNode.NextNode = currentNode.NextNode;
                    currentNode.NextNode.PrevNode = currentNode.PrevNode;
                    currentNode.NextNode = null;
                    currentNode.PrevNode = null;
                    return;
                }
                currentNode = currentNode.NextNode;
                currentIndex++;
            }
            count--;
        }

        public void RemoveNode(Node node)
        {
            if (node.PrevNode == null)
            {
                var newStartNode = startNode.NextNode;
                startNode.NextNode = null;
                startNode = newStartNode;
                return;
            }
            if (node.NextNode == null)
            {
                var newEndNode = endNode.PrevNode;
                endNode.PrevNode = null;
                endNode = newEndNode;
                return;
            }
            
            node.PrevNode.NextNode = node.NextNode;
            node.NextNode.PrevNode = node.PrevNode;
            node.NextNode = null;
            node.PrevNode = null;
            return;
 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var testNode = new Node()
            {
                Value = 777
            };

            var linkedList = new LinkedList();
            linkedList.AddNode(111);
            linkedList.AddNode(222);
            linkedList.AddNode(333);
            linkedList.FindNode(222);
            linkedList.GetCount();
            linkedList.RemoveNode(2);            

        }
    }
}
