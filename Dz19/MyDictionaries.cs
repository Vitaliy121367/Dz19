namespace Dz19
{
    public class MyDictionaries
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public List<string> Translations { get; set; }= new List<string>();
        public MyDictionaries() { }
        public MyDictionaries(int id, string word, string translation) 
        {
            Id = id;
            Word = word;
            Translations.Add(translation);
        }
        public void AddTranslation(string translation)
        {
            Translations.Add(translation);
        }
        public override string ToString()
        {
            return $"Id: {Id}\nWord: {Word}\nTranslations: {string.Join(", ", Translations)}";
        }
    }
}
