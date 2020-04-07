using System;
using NumberToAWord;
public class Program
{
    static void Main()
    {
        var translator = new NumberToWordTranslator();
        ConsoleUser.ConsoleController(translator);
    }
}


