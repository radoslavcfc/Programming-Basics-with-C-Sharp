using System;

namespace MentorMate
{
    public class StartUp
    {
        static void Main()
        {
            while (true)
            {
                //Infinite loop to keep the application alive in case the user inserts incorrect input.
                try
                {
                    Console.Write("Please enter a digit: ");
                    int rowsCount = int.Parse(Console.ReadLine());

                    var logo = new LogoDrawer(rowsCount);
                    logo.PrintOutput();
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}

