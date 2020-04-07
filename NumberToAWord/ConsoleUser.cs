using System;

namespace NumberToAWord
{
    public static class ConsoleUser
    {
        private static string onlyNumbersMessage = "Works only with numbers!";
        private static string onLeaveMessage = "You have choose to exit!\nThank you!\nGood bye!";
        private static string inRangeMessage = "Number must be between 0 and 999";
        private static string inputRequestMessage = "Type a number [0-999] or press 'E' to exit: ";
        private static string exitCommand = "E".ToLower();
        
        public static void ConsoleController(NumberToWordTranslator translator)
        {
            while (true)
            {
                var input = InputRequestConsole();

                if (input == exitCommand)
                {
                    ConsoleErrorMessage(onLeaveMessage);
                    break;
                }

                int numberToTranslate;
                var isNumber = int.TryParse(input, out numberToTranslate);

                if (!isNumber)
                {
                    ConsoleErrorMessage(onlyNumbersMessage);
                }

                else if (numberToTranslate < 0 || numberToTranslate > 999)
                {
                    ConsoleErrorMessage(inRangeMessage);
                }

                else
                {
                    var result = translator.DigitController(numberToTranslate);
                    CorrectOutputConsole(result);
                }
            }
        }
        private static void ConsoleWhiteLines()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('*', 40));
        }

        private static void ConsoleErrorMessage(string message)
        {
            ConsoleWhiteLines();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            ConsoleWhiteLines();
        }

        private static string InputRequestConsole()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(inputRequestMessage);
            Console.ForegroundColor = ConsoleColor.Blue;
            return Console.ReadLine();
        }
        private static void CorrectOutputConsole(string result)
        {
            ConsoleWhiteLines();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);
            ConsoleWhiteLines();
        }
        
    }
}