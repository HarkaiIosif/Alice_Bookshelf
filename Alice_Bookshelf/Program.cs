// See https://aka.ms/new-console-template for more information
TextReader reader=new StreamReader(@"..\..\Input.txt");
List<string> Lines = new List<string>();
string buffer;
while ((buffer = reader.ReadLine()) != null) 
{
    Lines.Add(buffer);
}
foreach (string t in Lines)
{
    Stack<char> shelves = new Stack<char>();
    Stack<char> temp = new Stack<char>();
    char[] vect;
    foreach (char c in t)
    {
        shelves.Push(c);
    }
    vect = shelves.ToArray();
    shelves.Clear();
    for (int i = vect.Length - 1; i >= 0; i--)
    {
        shelves.Push(vect[i]);
        if (shelves.Peek() == '\\')
        {
            shelves.Pop();
            while (shelves.Peek() != '/')
            {
                char k = shelves.Pop();
                temp.Push(k);
            }
            shelves.Pop();
            char[] te = temp.ToArray();
            for (int j = te.Length - 1; j >= 0; j--)
            {
                char k = te[j];
                shelves.Push(k);
            }
            temp.Clear();
        }
    }
    vect = shelves.ToArray();
    for (int i = vect.Length - 1; i >= 0; i--) Console.Write(vect[i]);
    Console.WriteLine();
}
Console.ReadKey();
