public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));     // Output: Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));   // Output: Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train"));   // Output: ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Adds a translation from 'fromWord' to 'toWord'.
    /// If the word already exists, it updates the translation.
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the given word. If not found, returns "???".
    /// </summary>
    public string Translate(string fromWord)
    {
        return _words.TryGetValue(fromWord, out var translation) ? translation : "???";
    }
}