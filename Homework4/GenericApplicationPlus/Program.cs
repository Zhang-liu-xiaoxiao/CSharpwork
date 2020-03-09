using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApplication {

  // 链表节点
  public class Node<T> {
    public Node<T> Next { get; set; }
    public T Data { get; set; }

    public Node(T t) {
      Next = null;
      Data = t;
    }
  }

  //泛型链表类
  public class GenericList<T> {
    private Node<T> head;
    private Node<T> tail;

        public void Foreach(Action<T> action)
        {
            
            Node<T> n = this.head;
            for (; n != null; n = n.Next)
                action(n.Data);
        }


    public GenericList() {
      tail = head = null;
    }

    public Node<T> Head {
      get => head;
    }

    public void Add(T t)
    {
        Node<T> n = new Node<T>(t);
        if (tail == null)
        {
            head = tail = n;
        }
        else
        {
            tail.Next = n;
            tail = n;
        }
    }

  }

  class Program {
    

    static void Main(string[] args) {
      // 整型List
      GenericList<int> intlist = new GenericList<int>();
      for (int x = 0; x < 10; x++) {
        intlist.Add(x);
      }
      for (Node<int> node = intlist.Head; 
            node != null; node = node.Next) {
        Console.WriteLine(node.Data);
      }

      // 字符串型List
      GenericList<string> strList = new GenericList<string>();
      for (int x = 0; x < 10; x++) {
        strList.Add("str"+x);
      }
      for (Node<string> node = strList.Head; 
              node != null; node = node.Next) {
        Console.WriteLine(node.Data);
      }

            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            intlist.Foreach(x => Console.WriteLine(x));
            intlist.Foreach(x => { min = (x < min ? x : min); });
            intlist.Foreach(x => { max = (x > max ? x : max); });
            intlist.Foreach(x => sum += x);
            Console.WriteLine($"max:{max},min:{min},sum:{sum}");
            Action<int> action = x =>
            {
                sum+=x;
            };
            intlist.Foreach(action);
            Console.WriteLine("第二次求和"+sum);
            //      Array.ForEach(strList, (Node<String> x) => { Console.WriteLine(x.Data); });

        }


  }
}