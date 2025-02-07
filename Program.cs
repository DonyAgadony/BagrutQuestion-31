using System.Reflection;

namespace DataStructure.LinkedList;

public class Node<T> // <T> = generic
{
    private T value; // The value of the current cell

    private Node<T>? next; // Pointer to the next cell

    public Node(T value)
    {
        this.value = value;
        next = null;
    }

    public Node(T value, Node<T> next)
    {
        this.value = value;
        this.next = next;
    }

    public T GetValue()
    {
        return this.value;
    }

    public void SetValue(T value)
    {
        this.value = value;
    }

    public Node<T>? GetNext()
    {
        return this.next;
    }

    public void SetNext(Node<T>? next)
    {
        this.next = next;
    }

    public bool HasNext()
    {
        return next != null;
    }

    public override string ToString()
    {
        return value!.ToString()!;
    }
}

class Student
{
    public int id;
    public int MathGrade;
    public int EnglishGrade;
    public int avg;
}
class Program
{
    public static Node<Student> UpdateAVG(Node<Student> head)
    {
        Node<Student> temp = head;
        while (temp.GetNext() != null)
        {
            temp.GetValue().avg = (temp.GetValue().MathGrade + temp.GetValue().EnglishGrade) / 2;
            temp = temp.GetNext();
        }
        return head;
    }
    public static int GetBiggestAVG(Node<Student> head)
    {
        int max = int.MinValue;
        int biggestID = 0;
        head = UpdateAVG(head);
        Node<Student> temp = head;
        while (temp.GetNext() != null)
        {
            if (temp.GetValue().avg > max)
            {
                max = temp.GetValue().avg;
                biggestID = temp.GetValue().id;
            }
        }
        return biggestID;
    }
    public static void AddStudent(Node<Student> head, Student NewStudent)
    {
        Node<Student> temp = head;
        while (temp.GetNext() != null)
        {
            temp = temp.GetNext();
        }
        temp.SetNext(new Node<Student>(NewStudent));
        temp = temp.GetNext();
        temp = UpdateAVG(temp);
    }
}