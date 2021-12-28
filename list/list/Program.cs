using list;

MyList<int> l = new();
l.Add(1);
l.Add(2);
l.Add(3);
Console.WriteLine("at zero index: " + l.Get(0));
Console.WriteLine("count: " + l.Count);
l.Remove(0);
Console.WriteLine("at zero index: " + l.Get(0));
Console.WriteLine("count: " + l.Count);
