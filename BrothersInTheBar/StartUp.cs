using System;

namespace BrothersInTheBar
{
    public class StartUp
    {
        static int _roundCounter = 0;
        public static void SearchForConsecutive(int[] array)
        {
            int consCounter = 1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    consCounter++;

                    if (consCounter == 3)
                    {
                        _roundCounter++;

                        //the barman removes the empty glasses
                        var newArray = RemoveEmptyGlasses(array, i - 1);

                        //If newArray contains less than 3 elements a round is not possible
                        if (newArray.Length >= 3)
                        {
                            SearchForConsecutive(newArray);
                        }
                    }
                }
                //resetting the counter if only 2 equal elements found and third is not equal
                else if (consCounter > 1)
                {
                    consCounter = 1;
                }
            }

        }
        public static int[] RemoveEmptyGlasses(int[] originalArray, int indexToRemoveFrom)
        {
            var newArrSize = originalArray.Length - 3;
            var newArray = new int[newArrSize];

            for (int j = 0, i = 0; i < newArray.Length; i++, j++)
            {
                if (i == indexToRemoveFrom)
                {
                    // the old array index moves from the first occurance of the element from the round
                    // to the end of the sequence
                    j += 3;
                }
                newArray[i] = originalArray[j];
            }

            return newArray;
        }

        public static int[] ManualInputWithValidation()
        {
            while (true)
            {
                //Infinite loop is used to give the user a chance to fill up the 
                //correct information without breaking the application

                Console.Write("Please enter the size of the array:");

                string arrayLenghtInput = Console.ReadLine();
                int arrayLength;
                bool isADigit = int.TryParse(arrayLenghtInput, out arrayLength);

                if (isADigit)
                {
                    if (arrayLength < 1 || arrayLength > 10000)
                    {
                        Console.WriteLine("Number must be in range [1-10000]");
                        continue;
                    }

                    Console.WriteLine("Thank you! Now please fill up the array:");
                }

                else
                {
                    Console.WriteLine("Please enter a digit!");
                    continue;
                }

                int[] glasses = new int[arrayLength];

                for (int i = 0; i < arrayLength; i++)
                {
                    Console.Write($"Array[{i}]: ");

                    string singleGlassInput = Console.ReadLine();
                    int singleGlass;
                    bool isItADigit = int.TryParse(singleGlassInput, out singleGlass);

                    if (isItADigit)
                    {
                        if (singleGlass < 1 || singleGlass > 100000)
                        {
                            Console.WriteLine("Number must be in range [1-100000]");
                            i--;
                            continue;
                        }
                        glasses[i] = singleGlass;
                    }
                    else
                    {
                        {
                            Console.WriteLine("Please enter a digit!");
                            i--;
                            continue;
                        }
                    }
                }
                return glasses;
            }
        }

        static void Main(string[] args)
        {

            int[] glasses = ManualInputWithValidation();


            //Test arrays if you don`t want to fill up the array manually:

            //int[] glasses = { 1, 1, 2, 3, 3, 3, 2, 2, 1, 1}; //  ---- Expected output : brothersInTheBar(glasses) = 3
            //int[] glasses = {1, 1, 2, 1, 2, 2, 1, 1};      //    ---- Expected output : brothersInTheBar(glasses) = 0

            SearchForConsecutive(glasses);

            Console.WriteLine($"brothersInTheBar(glasses) = {_roundCounter}");
        }
    }
}


