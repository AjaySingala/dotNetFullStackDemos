#region Counting Elements
//var brands = new HashSet<string>();

//brands.Add("Wilson");
//brands.Add("Nike");
//brands.Add("Volvo");
//brands.Add("IBM");
//brands.Add("IBM");

//int nOfElements = brands.Count;

//Console.WriteLine($"The set contains {nOfElements} elements");
//Console.WriteLine(string.Join(", ", brands));
#endregion

#region Removing elements.
//var brands = new HashSet<string>
//{
//    "Wilson", "Nike", "Volvo", "Kia", "Lenovo"
//};

//Console.WriteLine(string.Join(", ", brands));

//brands.Remove("Kia");
//brands.Remove("Lenovo");

//Console.WriteLine(string.Join(", ", brands));

//brands.Clear();

//if (brands.Count == 0)
//{
//    Console.WriteLine("The brands set is empty");
//}

//var words = new HashSet<string>
//{
//    "sky", "blue", "cup", "cold", "cloud", "pen", "bank"
//};

//words.RemoveWhere(word => word.Length == 3);
//Console.WriteLine(string.Join(", ", words));

#endregion

#region Looping.
//var words = new HashSet<string>
//{
//    "sky", "blue", "cup", "cold", "cloud", "pen", "bank"
//};

//foreach (var word in words)
//{
//    Console.WriteLine(word);
//}

//Console.WriteLine("----------------------");

//var it = words.GetEnumerator();

//while (it.MoveNext())
//{
//    Console.WriteLine(it.Current);
//}

#endregion

#region Contains.
//var words = new HashSet<string>
//{
//    "sky", "blue", "cup", "cold", "cloud", "pen", "bank"
//};

//Console.WriteLine(words.Contains("sky"));
//Console.WriteLine(words.Contains("water"));

//Console.WriteLine("-----------------");

//var users = new HashSet<User>
//{
//    new User("John Doe", "gardener"),
//    new User("Roger Roe", "driver"),
//    new User("Lucy Smith", "teacher")
//};

//var u1 = new User("John Doe", "gardener");
//var u2 = new User("Jane Doe", "student");

//Console.WriteLine(users.Contains(u1));
//Console.WriteLine(users.Contains(u2));

//record User(string name, string occupation);

#endregion

#region UnionWith and IntersectWith
//var vals1 = new HashSet<int> { 1, 2, 3, 4, 5 };
//var vals2 = new HashSet<int> { 6, 7, 8, 9, 10 };

//vals1.UnionWith(vals2);
//Console.WriteLine(string.Join(", ", vals1));

//var vals3 = new HashSet<int> { 1, 2, 3, 4, 5 };
//var vals4 = new HashSet<int> { 3, 4, 5, 6, 7 };

//vals3.IntersectWith(vals4);
//Console.WriteLine(string.Join(", ", vals3));

#endregion
