public class Program
{
    public static void Main(string[]args)
    {
        ObjectsStorage<int> o = new ObjectsStorage<int>(0);
        Console.WriteLine(o);

        o.Push(1);
        o.Push(2);
        o.Push(3);

        Console.WriteLine(o);

        o.InsertAtIndex(6,-1);
        
        Console.WriteLine(o);

        Console.WriteLine(o.Pull(6));
        Console.WriteLine(o.Pull(10));

        ObjectsStorage<int> empty = new ObjectsStorage<int>();

        Console.WriteLine(empty.Pull(100)+"\n"); // so then generic null which turns into an int equals to zero!

        Console.WriteLine(o);
        Console.WriteLine(o.Pop(2));
        Console.WriteLine(o);

        int[] arr = o.Array();
        for(int i=0; i<arr.Length; i++)
            Console.WriteLine(arr[i]);
        Console.WriteLine(o);

        int[] intArr = new int[0]; //{ 1,2,3};
        o.Copy(intArr);

        Console.WriteLine(o);

        empty.Push(1); // bug here, incorrect push, need to figure how to replace null/empty value with new one
        o.Copy(empty);
        Console.WriteLine(o);
    }
}