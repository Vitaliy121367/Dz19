using System.Text.Json;

namespace Dz19
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter name file: ");
            string sfile=Console.ReadLine();
            string path = Directory.GetCurrentDirectory() + @"\"+ sfile +".json";
            //MyDictionaries myDictionarie1 = new MyDictionaries(1, "Orange", "Апельсин");
            //myDictionarie1.AddTranslation("Оранжевый");
            //myDictionaries.Add(myDictionarie1);

            //MyDictionaries myDictionarie2 = new MyDictionaries(2, "All", "Все");
            //myDictionarie2.AddTranslation("Всё");
            //myDictionaries.Add(myDictionarie2);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            while (true)
            {
                if (File.Exists(path))
                {
                    string dictionariesFromFile = File.ReadAllText(path);
                    List<MyDictionaries> dictionariesFromJson = JsonSerializer.Deserialize<List<MyDictionaries>>(dictionariesFromFile);
                    Console.WriteLine("+----------------------+");
                    Console.WriteLine("| 1-Create dictionarie |");
                    Console.WriteLine("| 2-Create translation |");
                    Console.WriteLine("| 3-Delete dictionarie |");
                    Console.WriteLine("| 4-Delete translation |");
                    Console.WriteLine("| 5-Edit dictionarie   |");
                    Console.WriteLine("| 6-Edit translation   |");
                    Console.WriteLine("| 7-Search             |");
                    Console.WriteLine("| 8-Show All           |");
                    Console.WriteLine("| 9-Exit               |");
                    Console.WriteLine("+----------------------+");
                    int index = int.Parse(Console.ReadLine());

                    if (index == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Id, Word, Translation");
                        int id = int.Parse(Console.ReadLine());
                        string word = Console.ReadLine();
                        string translation = Console.ReadLine();
                        dictionariesFromJson.Add(new MyDictionaries(id, word, translation));
                        string dictionariesJson = JsonSerializer.Serialize(dictionariesFromJson, options);
                        File.WriteAllText(path, dictionariesJson);
                    }
                    else if (index == 2)
                    {
                        Console.Clear();
                        Console.Write("Enter Id: ");
                        int i = int.Parse(Console.ReadLine());
                        foreach (var item in dictionariesFromJson)
                        {
                            if (i == item.Id)
                            {
                                Console.Write("Enter Translation: ");
                                string translation = Console.ReadLine();
                                item.AddTranslation(translation);
                                string dictionariesJson = JsonSerializer.Serialize(dictionariesFromJson, options);
                                File.WriteAllText(path, dictionariesJson);
                                break;
                            }
                        }
                    }
                    else if (index == 3)
                    {
                        Console.Write("Enter Id: ");
                        int i = int.Parse(Console.ReadLine());
                        for (int j = 0; j < dictionariesFromJson.Count(); j++)
                        {
                            if (i == dictionariesFromJson[j].Id)
                            {
                                dictionariesFromJson.Remove(dictionariesFromJson[j]);
                                string dictionariesJson = JsonSerializer.Serialize(dictionariesFromJson, options);
                                File.WriteAllText(path, dictionariesJson);
                            }
                        }
                        Console.Clear();
                    }
                    else if (index == 4)
                    {
                        Console.Write("Enter Id: ");
                        int i = int.Parse(Console.ReadLine());
                        for (int j = 0; j < dictionariesFromJson.Count(); j++)
                        {
                            if (i == dictionariesFromJson[j].Id && dictionariesFromJson[j].Translations.Count() != 1)
                            {
                                Console.Write("Enter Num Translation: ");
                                i = int.Parse(Console.ReadLine());
                                dictionariesFromJson[j].Translations.RemoveAt(i - 1);
                                string dictionariesJson = JsonSerializer.Serialize(dictionariesFromJson, options);
                                File.WriteAllText(path, dictionariesJson);
                            }
                        }
                        Console.Clear();
                    }
                    else if (index == 5)
                    {
                        Console.Write("Enter Id: ");
                        int i = int.Parse(Console.ReadLine());
                        for (int j = 0; j < dictionariesFromJson.Count(); j++)
                        {
                            if (i == dictionariesFromJson[j].Id)
                            {
                                Console.Write("Enter New Word: ");
                                string word = Console.ReadLine();
                                dictionariesFromJson[j].Word = word;
                                string dictionariesJson = JsonSerializer.Serialize(dictionariesFromJson, options);
                                File.WriteAllText(path, dictionariesJson);
                            }
                        }
                        Console.Clear();
                    }
                    else if (index == 6)
                    {
                        Console.Write("Enter Id: ");
                        int i = int.Parse(Console.ReadLine());
                        for (int j = 0; j < dictionariesFromJson.Count(); j++)
                        {
                            if (i == dictionariesFromJson[j].Id && dictionariesFromJson[j].Translations.Count() != 1)
                            {
                                Console.Write("Enter Num Translation: ");
                                i = int.Parse(Console.ReadLine());
                                Console.Write("Enter New Translation: ");
                                string translation = Console.ReadLine();
                                dictionariesFromJson[j].Translations[i-1] = translation;
                                string dictionariesJson = JsonSerializer.Serialize(dictionariesFromJson, options);
                                File.WriteAllText(path, dictionariesJson);
                            }
                        }
                        Console.Clear();
                    }
                    else if (index == 7)
                    {
                        Console.Clear();
                        Console.WriteLine("+------------------+");
                        Console.WriteLine("| 1-By Id          |");
                        Console.WriteLine("| 2-By Word        |");
                        Console.WriteLine("| 3-By Translation |");
                        Console.WriteLine("+------------------+"); 
                        Console.Write("Enter: ");
                        int i = int.Parse(Console.ReadLine());
                        if (i == 1)
                        {
                            Console.Write("Enter Id: ");
                            i = int.Parse(Console.ReadLine());
                            foreach (var item in dictionariesFromJson)
                            {
                                if (i==item.Id)
                                {
                                    Console.WriteLine(item);
                                    break;
                                }
                            }
                        }
                        else if (i == 2)
                        {
                            Console.Write("Enter Word: ");
                            string word = Console.ReadLine();
                            foreach (var item in dictionariesFromJson)
                            {
                                if (word == item.Word)
                                {
                                    Console.WriteLine(item);
                                    break;
                                }
                            }
                        }
                        else if (i == 3)
                        {
                            Console.Write("Enter Translation: ");
                            string translation = Console.ReadLine();
                            foreach (var item in dictionariesFromJson)
                            {
                                foreach (var item1 in item.Translations)
                                {
                                    if (translation == item1)
                                    {
                                        Console.WriteLine(item);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                    }
                    else if (index == 8)
                    {
                        Console.Clear();
                        foreach (var item in dictionariesFromJson)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else if (index == 9)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
                else
                {
                    File.WriteAllText(path, "[]");

                    Console.WriteLine("Id, Word, Translation");
                    int id = int.Parse(Console.ReadLine());
                    string word = Console.ReadLine();
                    string translation = Console.ReadLine();

                    List<MyDictionaries> myDictionaries = new List<MyDictionaries>();
                    myDictionaries.Add(new MyDictionaries(id, word, translation));

                    string dictionariesJson = JsonSerializer.Serialize(myDictionaries, options);
                    File.WriteAllText(path, dictionariesJson);
                }
            }
        }
    }
}
