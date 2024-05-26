using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class ObjectsStorage<T>
{
    private ObjectsStorage<T> next;
    private T value;
    private int index;
    // private int total;
    // private ObjectsStorage<T>last;

    public ObjectsStorage()
    {
        next = null;
        this.index = 0;
    }
    public ObjectsStorage(T value)
    {
        next = null;
        this.value = value;
        index = 0;
    }
    private ObjectsStorage(int index)
    {
        next = null;
        this.index = index;
    }
    private ObjectsStorage(int index, T value)
    {
        next = null;
        this.value = value;
        this.index = index;
    }
    public void Push(T value)
    {
        if (this.value == null)
        {
            this.value = value;
            return;
        }
        ObjectsStorage<T> temp = this;
        int index = 0;
        while (temp.next != null)
        {
            temp = temp.next;
            index++;
        }
        temp.next = new ObjectsStorage<T>(index, value);
    }
    public void Push()
    {
        ObjectsStorage<T> temp = this;
        int index = 0;
        while (temp.next != null)
        {
            temp = temp.next;
            index++;
        }
        temp.next = new ObjectsStorage<T>(index);
    }
    public override string ToString()
    {
        ObjectsStorage<T> temp = this;
        string str = "[";
        while (temp.next != null)
        {
            if (temp.value != null)
                str += temp.value.ToString() + ",";
            temp = temp.next;
        }
        if (temp.value != null)
            str += temp.value.ToString();
        str += "]";
        return str;
    }
    public void InsertAtIndex(int index, T value)
    {
        ObjectsStorage<T> temp = this;
        if (temp == null)
            temp = new ObjectsStorage<T>();
        while (temp.next != null && temp.index != index - 1)
            temp = temp.next;
        if (temp.next == null)
        {
            while (temp.index != index - 1)
            {
                temp.next = new ObjectsStorage<T>(temp.index + 1);
                temp = temp.next;
            }
            temp.next = new ObjectsStorage<T>(index, value);
        }
        else
        {
            ObjectsStorage<T> temp2 = temp.next;
            temp.next = new ObjectsStorage<T>(index, value);
            temp = temp.next;
            temp.next = temp2;
            while (temp.next != null)
            {
                index++;
                temp.index = index;
                temp = temp.next;
            }
        }
    }
    public T Pull(int index)
    {
        ObjectsStorage<T> temp = this;
        if (temp == null)
            temp = new ObjectsStorage<T>();
        while (temp.next != null && temp.index != index)
            temp = temp.next;
        return temp.value;

    }
    public T Pop(int index)
    {
        //ObjectsStorage<T> temp = this;
        //ObjectsStorage<T> last = this;
        //if (temp == null)
        //{
        //    temp = new ObjectsStorage<T>();
        //    //temp.Push(temp.value);
        //}
        //while (temp.next != null && temp.index != index - 1)
        //{
        //    last = temp;
        //    temp = temp.next;
        //}
        //if (temp.next == null)
        //    last.next = null;
        //else
        //    last.next = temp.next;
        //return temp.value;

        ObjectsStorage<T> temp = this;
        if (temp == null) // if current is null create new empty object (with null/default values)
            temp = new ObjectsStorage<T>();
        ObjectsStorage<T> last = temp;
        if (temp.next == null) // if next is null return current temp's value
            return temp.value;
        if (index < temp.index) // if index comes before the objects index return 0
            return new ObjectsStorage<T>().value;
        while (temp.next != null && temp.index != index-1)
        {
            last = temp;
            temp = temp.next;
        }
        last.next = temp.next;
        T answer = temp.value;
        last.next.index = temp.index;
        while(temp.next!=null)
        {
            temp.next.index = temp.index + 1;
            temp = temp.next;
        }
        return answer;

    }
    public void Swap(int index1, int index2)
    {
        ObjectsStorage<T> first = this.Find(index1);
        ObjectsStorage<T> second = this.Find(index2);
        T value = first.value;
        first.value = second.value;
        second.value = value;
    }
    public void Replace(int index, T value) // is this necessery?
    {
        ObjectsStorage<T> temp = this;
        while (this.index != index)
            temp = temp.next;
        temp.value = value;
    }
    public int Find(ObjectsStorage<T> storage)
    {
        ObjectsStorage<T> temp = this;
        while (temp != null && temp != storage)
            temp = temp.next;
        return temp.index;
    }
    public ObjectsStorage<T> Find(int index)
    {
        ObjectsStorage<T> temp = this;
        while (temp != null && temp.index != index)
            temp = temp.next;
        return temp;
    }
    public T[] Array()
    {
        int size = this.Size();
        T[] answer = new T[size];
        ObjectsStorage<T> temp = this;
        for (int i = 0; i < size; i++)
        {
            answer[i] = temp.value;
            temp = temp.next;
        }
        return answer;
    }
    public int Size()
    {
        int size = 0;
        ObjectsStorage<T> temp = this;
        while (temp != null)
        {
            size++;
            temp = temp.next;
        }
        return size;
    }
    public ObjectsStorage<T> Copy()
    {
        ObjectsStorage<T>answer=new ObjectsStorage<T>();
        ObjectsStorage<T>temp = this;
        while(temp!=null)
        {
            answer.Push(temp.value);
            temp = temp.next;
        }
        return answer;
    }
    public void Copy(T[]arr)
    {
        ObjectsStorage<T> last = this;
        ObjectsStorage<T> temp = this;
        for (int i = 0; i < arr.Length; i++)
        {
            temp.value = arr[i];
            if (temp.next == null)
                temp.next = new ObjectsStorage<T>(temp.index);
            last = temp;
            temp = temp.next;
        }
        while (temp != null)
        {
            last.next = null;
            last = temp;
            temp = temp.next;
        }
    }
    public void Copy(ObjectsStorage<T> storage)
    {
        ObjectsStorage<T> last = this;
        ObjectsStorage<T> temp = this;
        while(storage!=null)
        {
            temp.value = storage.value;
            storage=storage.next;
            if (temp.next == null)
                temp.next = new ObjectsStorage<T>(temp.index);
            last = temp;
            temp = temp.next;
        }
        while (temp != null)
        {
            last.next = null;
            last = temp;
            temp = temp.next;
        }
    }
}