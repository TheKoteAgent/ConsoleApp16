using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //1
        int a = 5, b = 10;
        Console.WriteLine($"Before swap: a = {a}, b = {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"After swap: a = {a}, b = {b}");

        //2
        PriorityQueue<string> priorityQueue = new PriorityQueue<string>();
        priorityQueue.Enqueue("Task 1", 3);
        priorityQueue.Enqueue("Task 2", 1);
        priorityQueue.Enqueue("Task 3", 2);

        Console.WriteLine("\nPriority Queue:");
        while (!priorityQueue.IsEmpty)
        {
            Console.WriteLine($"Dequeue: {priorityQueue.Dequeue()}");
        }

        //3
        CircularQueue<int> circularQueue = new CircularQueue<int>(5);
        for (int i = 1; i <= 5; i++)
        {
            circularQueue.Enqueue(i);
        }

        Console.WriteLine("\nCircular Queue:");
        while (!circularQueue.IsEmpty)
        {
            Console.WriteLine($"Dequeue: {circularQueue.Dequeue()}");
        }

        //4
        LinkedList<int> linkedList = new LinkedList<int>();
        for (int i = 1; i <= 5; i++)
        {
            linkedList.AddLast(i);
        }

        Console.WriteLine("\nLinked List:");
        while (linkedList.Count > 0)
        {
            Console.WriteLine($"RemoveFirst: {linkedList.Count}");
            linkedList.RemoveFirst();
        }

        //5
        DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
        for (int i = 1; i <= 5; i++)
        {
            doublyLinkedList.AddLast(i);
        }

        Console.WriteLine("\nDoubly Linked List:");
        while (doublyLinkedList.Count > 0)
        {
            Console.WriteLine($"RemoveFirst: {doublyLinkedList.Count}");
            doublyLinkedList.RemoveFirst();
        }
    }

    //1
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

 2
    public class PriorityQueue<T>
    {
        private List<Tuple<T, int>> items = new List<Tuple<T, int>>();

        public void Enqueue(T item, int priority)
        {
            items.Add(new Tuple<T, int>(item, priority));
            items.Sort((x, y) => x.Item2.CompareTo(y.Item2));
        }

        public T Dequeue()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T item = items[0].Item1;
            items.RemoveAt(0);
            return item;
        }

        public int Count => items.Count;

        public bool IsEmpty => Count == 0;
    }

    public class CircularQueue<T>
    {
        private T[] array;
        private int front;
        private int rear;
        private int capacity;
        private int count;

        public CircularQueue(int size)
        {
            array = new T[size];
            capacity = size;
            front = 0;
            rear = -1;
            count = 0;
        }

        public void Enqueue(T item)
        {
            if (count == capacity)
            {
                throw new InvalidOperationException("Queue is full");
            }
            rear = (rear + 1) % capacity;
            array[rear] = item;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T item = array[front];
            front = (front + 1) % capacity;
            count--;
            return item;
        }

        public int Count => count;

        public bool IsEmpty => count == 0;

        public bool IsFull => count == capacity;
    }


    public class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T value)
        {
            Value = value;
        }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public int Count => count;

        public void AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            count++;
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            count++;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            head = head.Next;
            count--;
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                LinkedListNode<T> current = head;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                tail = current;
                tail.Next = null;
            }
            count--;
        }
    }


    public class DoublyLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Prev { get; set; }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
    }

    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;
        private DoublyLinkedListNode<T> tail;
        private int count;

        public int Count => count;

        public void AddFirst(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            count++;
        }

        public void AddLast(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            count++;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            head = head.Next;
            if (head != null)
            {
                head.Prev = null;
            }
            else
            {
                tail = null;
            }
            count--;
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.Prev;
                tail.Next = null;
            }
            count--;
        }
    }
}
